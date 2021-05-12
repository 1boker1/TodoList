using Mvc.Scripts.Signals;

namespace TodoListApp.Notifications
{
    public class ShowDeletePopupNotification<ITaskInfo> : ASignal<ITaskInfo> { }
}