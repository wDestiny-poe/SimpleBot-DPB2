using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBot.Extensions.Positions;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using Message = DreamPoeBot.Loki.Bot.Message;

namespace SimpleBot.Extensions.CommonTasks
{
    public class IdTask : ITask
    {
        public async Task<bool> Run()
        {
            var area = World.CurrentArea;

            if (!area.IsTown && !area.IsHideoutArea)
                return false;

            var itemsToId = new List<Vector2i>();
            var itemFilter = ItemEvaluator.Instance;

            foreach (var item in Inventories.InventoryItems)
            {
                if (item.IsIdentified || item.IsCorrupted || item.IsMirrored)
                    continue;

                if (!itemFilter.Match(item, EvaluationType.Id))
                    continue;

                itemsToId.Add(item.LocationTopLeft);
            }

            if (itemsToId.Count == 0)
            {
                GlobalLog.Info("[IdTask] No items to identify.");
                return false;
            }

            // Add routine to identify with doriyani
           
            await Coroutines.CloseBlockingWindows();
            return true;
        }

        private static async Task<bool> Identify(Vector2i itemPos)
        {
            var item = LokiPoe.InGameState.InventoryUi.InventoryControl_Main.Inventory.FindItemByPos(itemPos);
            if (item == null)
            {
                GlobalLog.Error($"[Identify] Fail to find item at {itemPos} in player's inventory.");
                return false;
            }

            var scroll = Inventories.InventoryItems
                .Where(s => s.Name == CurrencyNames.Wisdom)
                .OrderBy(s => s.StackCount)
                .FirstOrDefault();

            if (scroll == null)
            {
                GlobalLog.Error("[Identify] No id scrolls.");
                return false;
            }

            var name = item.Name;

            GlobalLog.Debug($"[Identify] Now using id scroll on \"{name}\".");

            if (!await LokiPoe.InGameState.InventoryUi.InventoryControl_Main.PickItemToCursor(scroll.LocationTopLeft, true))
                return false;

            if (!await LokiPoe.InGameState.InventoryUi.InventoryControl_Main.PlaceItemFromCursor(itemPos))
                return false;

            if (!await Wait.For(() => IsIdentified(itemPos), "item identification"))
                return false;

            GlobalLog.Debug($"[Identify] \"{name}\" has been successfully identified.");
            return true;
        }

        private static bool IsIdentified(Vector2i pos)
        {
            var item = LokiPoe.InGameState.InventoryUi.InventoryControl_Main.Inventory.FindItemByPos(pos);
            if (item == null)
            {
                GlobalLog.Error("[Identify] Unexpected error. Item became null while waiting for identification.");
                ErrorManager.ReportError();
                return true;
            }
            return item.IsIdentified;
        }

        #region Unused interface methods

        public MessageResult Message(Message message)
        {
            return MessageResult.Unprocessed;
        }

        public async Task<LogicResult> Logic(Logic logic)
        {
            return LogicResult.Unprovided;
        }

        public void Tick()
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public string Name => "IdTask";
        public string Description => "Task that handles item identification.";
        public string Author => "ExVault";
        public string Version => "1.0";

        #endregion
    }
}