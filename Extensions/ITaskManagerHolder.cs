using DreamPoeBot.Loki.Bot;

namespace SimpleBot.Extensions
{
    public interface ITaskManagerHolder
    {
        TaskManager GetTaskManager();
    }
}