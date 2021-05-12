using Mvc.Scripts.Signals;

namespace TodoListApp.Notifications
{
    public class AddTaskNotification<ITaskInfo> : ASignal<ITaskInfo> { }
}