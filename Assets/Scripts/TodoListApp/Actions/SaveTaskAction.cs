using Mvc.Scripts.Signals;

namespace TodoListApp.Notifications
{
    public class SaveTaskAction<ITaskInfo> : ASignal<ITaskInfo> { }
}