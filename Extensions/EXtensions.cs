using System.Threading.Tasks;
using System.Windows.Controls;
using SimpleBot.Extensions.Global;
using log4net;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using settings = SimpleBot.Extensions.Settings;
using Message = DreamPoeBot.Loki.Bot.Message;
using UserControl = System.Windows.Controls.UserControl;

namespace SimpleBot.Extensions
{
    public class EXtensions : IContent, IUrlProvider
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();
        private Gui _gui;

        public static void AbandonCurrentArea()
        {
            var botName = BotManager.Current.Name;
            if (botName.Contains("QuestBot"))
            {
                Travel.RequestNewInstance(World.CurrentArea);
            }
            else if (botName.Contains("MapBot"))
            {
                BotManager.Current.Message(new Message("MB_set_is_on_run", null, false));
            }
        }

        #region Unused interface methods

        public async Task<LogicResult> Logic(Logic logic)
        {
            return LogicResult.Unprovided;
        }

        public MessageResult Message(Message message)
        {
            return MessageResult.Unprocessed;
        }

        public void Initialize()
        {
            Log.DebugFormat("[SimpletBot Extensions] Initialize");
        }

        public void Deinitialize()
        {
            Log.DebugFormat("[SimpletBot Extensions] Deinitialize");
        }

        public string Name => "SimpletBot Extensions";
        public string Description => "Global logic used by bot bases.";
        public string Author => "wDestiny based on ExVault";
        public string Version => "1.0";
        public JsonSettings Settings => settings.Instance;
        public UserControl Control => _gui ?? (_gui = new Gui());
        public string Url => "";

        #endregion
    }
}