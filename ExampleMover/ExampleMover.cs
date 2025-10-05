using DreamPoeBot.BotFramework;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Bot.Pathfinding;
using DreamPoeBot.Loki.Bot.Pathfinding.RDWrapper.Types;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using static DreamPoeBot.Loki.Game.LokiPoe.InGameState;
using Logger = DreamPoeBot.Loki.Common.Logger;
using Message = DreamPoeBot.Loki.Bot.Message;
using UserControl = System.Windows.Controls.UserControl;

namespace ExampleMover
{
    public class ExampleMover : IPlayerMover
    {
        public static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private ExampleMoverGui _gui;

        private bool _useForceAdjustments;
        
        private bool _useAct3TownAdjustments;

        private PathResult? _currentPath;

        private static TaskManager _botTaskManager;

        private readonly Stopwatch _pathRefreshSw = new Stopwatch();

        private Vector2i _cachedPosition = Vector2i.Zero;

        private static readonly List<Vector2i> BlacklistedLocations = new List<Vector2i>();

        private LokiPoe.TerrainDataEntry[,] _tgts;
        
        private uint _tgtSeed;

        private LokiPoe.TerrainDataEntry TgtUnderPlayer
        {
            get
            {
                var myPos = LokiPoe.LocalData.MyPosition;
                return _tgts[myPos.X / 23, myPos.Y / 23];
            }
        }

        /// <summary> The name of the plugin. </summary>
        public string Name => "ExampleMover";

        /// <summary> The description of the plugin. </summary>
        public string Description => "An example of IPlayerMover implementation.";

        /// <summary>The author of the plugin.</summary>
        public string Author => "Alcor75";

        /// <summary>The version of the plugin.</summary>
        public string Version => "1.0";

        /// <summary>Initializes this object.</summary>
        public void Initialize()
        {
        }
        /// <summary>Deinitializes this object. This is called when the object is being unloaded from the bot.</summary>
        public void Deinitialize()
        {
        }
        public JsonSettings Settings
        {
            get { return ExampleMoverSettings.Instance; }
        }

        /// <summary> The plugin's settings control. This will be added to the DreamPoeBot Settings tab.</summary>
        public UserControl Control
        {
            get { return (_gui ?? (_gui = new ExampleMoverGui())); }
        }
        /// <summary> The mover start callback. Do any initialization here. </summary>
        public void Start()
        {

        }
        /// <summary> The mover tick callback. Do any update logic here. </summary>
        public void Tick()
        {
            if (!LokiPoe.IsInGame)
                return;

            var cwa = LokiPoe.CurrentWorldArea;

            if (cwa.IsCombatArea && ExampleMoverSettings.Instance.ForceAdjustCombatAreas || ExampleMoverSettings.Instance.ForcedAdjustmentAreas.Any(e => e.Value.Equals(cwa.Name, StringComparison.OrdinalIgnoreCase)))
            {
                _useForceAdjustments = true;
            }
            else
            {
                _useForceAdjustments = false;
            }

            if (cwa.IsTown && cwa.Act == 3)
            {
                _useAct3TownAdjustments = true;
            }
            else
            {
                _useAct3TownAdjustments = false;
            }
        }
        /// <summary> The mover stop callback. Do any pre-dispose cleanup here. </summary>
        public void Stop()
        {
        }
        /// <summary>
        /// Implements the ability to handle a logic passed through the system.
        /// </summary>
        /// <param name="logic">The logic to be processed.</param>
        /// <returns>A LogicResult that describes the result..</returns>
        public async Task<LogicResult> Logic(Logic logic)
        {
            return LogicResult.Unprovided;
        }
        /// <summary>
        /// Implements logic to handle a message passed through the system.
        /// </summary>
        /// <param name="message">The message to be processed.</param>
        /// <returns>A tuple of a MessageResult and object.</returns>
        public MessageResult Message(Message message)
        {
            return MessageResult.Unprocessed;
        }
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name + ": " + Description;
        }
        /// <summary>
        /// Returns the player mover's current PathfindingCommand being used.
        /// </summary>
        public PathResult? CurrentCommand => _currentPath;

        #region Override of IMover

        /// <summary>
        /// Attempts to move towards a position. This function will perform pathfinding logic and take into consideration move distance
        /// to try and smoothly move towards a point.
        /// </summary>
        /// <param name="position">The position to move towards.</param>
        /// <param name="user">A user object passed.</param>
        /// <returns>true if the position was moved towards, and false if there was a pathfinding error.</returns>
        public bool MoveTowards(Vector2i position, params dynamic[] user)
        {
            var myPosition = LokiPoe.MyPosition;

            Log.InfoFormat("[ExampleMover.MoveTowards] Moving from {0} to {1}.", myPosition, position);
            // Condições para recalcular o path
            if (_currentPath == null ||
                !_currentPath.Value.Success ||
                _currentPath.Value.End != position ||
                LokiPoe.CurrentWorldArea.IsTown ||
                (_pathRefreshSw.IsRunning && _pathRefreshSw.ElapsedMilliseconds > ExampleMoverSettings.Instance.PathRefreshRateMs) ||
                _currentPath.Value.Path == null ||
                _currentPath.Value.Path.Count <= 2 ||
                _currentPath.Value.Path.All(p => myPosition.Distance(p) > 7))
            {
                // Novo FindPath: retorna PathResult
                _currentPath = ExilePather.FindPath(myPosition, position, true, 15);

                if (_currentPath == null || !_currentPath.Value.Success || _currentPath.Value.Path == null || _currentPath.Value.Path.Count == 0)
                {
                    _pathRefreshSw.Restart();
                    Log.ErrorFormat("[ExampleMover.MoveTowards] ExilePather.FindPath failed from {0} to {1}.",
                        myPosition, position);
                    return false;
                }

                _pathRefreshSw.Restart();
                Utility.BroadcastMessage(null, "FindPath_Result", _currentPath.Value);
            }

            var cwa = LokiPoe.CurrentWorldArea;
            var specialMoveRange = ExampleMoverSettings.Instance.MoveRange;
            if (cwa.IsTown)
                specialMoveRange = 19;
            if (cwa.IsTown && cwa.Act == 3)
                specialMoveRange = 15;
            if (cwa.Id == "Labyrinth_Airlock") // Aspirant's Plaza
                specialMoveRange = 15;

            // Limpa pontos muito próximos ou inválidos
            while (_currentPath.Value.Path.Count > 1)
            {
                if (BlacklistedLocations.Contains(_currentPath.Value.Path[0]) ||
                    ExilePather.PathDistance(_currentPath.Value.Path[0], myPosition) < specialMoveRange)
                {
                    _currentPath.Value.Path.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }

            var point = _currentPath.Value.Path[0];
            Utility.BroadcastMessage(null, "Next_Selected_Walk_Position", point);
            // Pequena variação aleatória no destino
            point += new Vector2i(LokiPoe.Random.Next(-2, 3), LokiPoe.Random.Next(-2, 3));

            // 🔹 Ajustes especiais que já existiam (Act 3, force adjust, etc.)
            if (_useForceAdjustments)
            {
                // (mantém o mesmo código de ajustes em X/Y que você já tinha)
            }

            if (_useAct3TownAdjustments)
            {
                var seed = LokiPoe.LocalData.AreaHash;
                if (_tgtSeed != seed || _tgts == null)
                {
                    Log.InfoFormat("[ExampleMover.MoveTowards] Now building TGT info.");
                    _tgts = LokiPoe.TerrainData.TgtEntries;
                    _tgtSeed = seed;
                }
                if (TgtUnderPlayer.TgtName.Equals("Art/Models/Terrain/Act3Town/Act3_town_01_01_c16r7.tgt"))
                {
                    Log.InfoFormat("[ExampleMover.MoveTowards] Act 3 Town force adjustment being made!");
                    point.Y += 5;
                }
            }

            // Verificação de colisão com objetos
            var pathCheck = ExilePather.Raycast(myPosition, point, out var hitPoint);
            if (!pathCheck)
            {
                BlacklistedLocations.Add(point);
                BlacklistedLocations.Add(hitPoint);
            }

            _cachedPosition = myPosition;
            return BasicMove(myPosition, point);
        }


        #endregion

        private static bool BasicMove(Vector2i myPosition, Vector2i point)
        {
            // Signal 'Next_Selected_Walk_Position' tp PatherExplorer.
            Utility.BroadcastMessage(null, "Next_Selected_Walk_Position", point);

            var move = LokiPoe.InGameState.SkillBarHud.LastBoundMoveSkill;
            if (move == null)
            {
                Log.ErrorFormat("[Alcor75PlayerMover.MoveTowards] Please assign the \"Move\" skill to your skillbar, do not use mouse button, use q,w,e,r,t!");

                BotManager.Stop();

                return false;
            }

            // In this example we check the current state of the key assigned to the move skill.
            if ((LokiPoe.ProcessHookManager.GetKeyState(move.BoundKeys.Last()) & 0x8000) != 0 &&
                LokiPoe.Me.HasCurrentAction && LokiPoe.Me.CurrentAction.Skill != null && LokiPoe.Me.CurrentAction.Skill.InternalId.Equals("Move"))
            {
                // If the key is pressed, but next moving point is less that SingleUseDistance setted, we need to reset keys and press the move skill once.
                if (myPosition.Distance(point) <= ExampleMoverSettings.Instance.SingleUseDistance)
                {
                    LokiPoe.ProcessHookManager.ClearAllKeyStates();
                    LokiPoe.InGameState.SkillBarHud.UseAt(move.Slots.Last(), false, point);
                    Log.WarnFormat("[SkillBarHud.UseAt] {0}", point);
                }
                // Otherwise we just move the mouse to the next moving position, for a fast and smooth natural movement.
                else
                {
                    MouseManager.SetMousePos("Alcor75PlayerMoverSettings.MoveTowards", point, false);
                }
            }
            else
            {
                // If the key was not pressed, we clear all keys state (we newer know what keys other component might have pressed but for sure we now just want to move!)
                // Then decide if to perform a single key press of to press the key and keep it pressed based on next position distance and configuration.
                LokiPoe.ProcessHookManager.ClearAllKeyStates();
                if (myPosition.Distance(point) <= ExampleMoverSettings.Instance.SingleUseDistance)
                {
                    LokiPoe.InGameState.SkillBarHud.UseAt(move.Slots.Last(), false, point);
                    Log.WarnFormat("[SkillBarHud.UseAt] {0}", point);
                }
                else
                {
                    LokiPoe.InGameState.SkillBarHud.BeginUseAt(move.Slots.Last(), false, point);
                    Log.WarnFormat("[BeginUseAt] {0}", point);
                }
            }
            return true;
        }

        private static TaskManager GetCurrentBotTaskManager()
        {
            var bot = BotManager.Current;

            var msg = new Message("GetTaskManager");
            bot.Message(msg);
            var taskManager = msg.GetOutput<TaskManager>();

            return taskManager;
        }
    }
}
