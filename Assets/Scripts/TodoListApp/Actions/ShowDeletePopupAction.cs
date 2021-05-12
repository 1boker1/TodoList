using Mvc.Scripts.Signals;

namespace TodoListApp.Actions
{
    public class ShowDeletePopupAction<ITaskInfo> : ASignal<ITaskInfo> { }
}