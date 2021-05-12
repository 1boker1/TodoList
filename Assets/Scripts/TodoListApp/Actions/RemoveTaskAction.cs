using Mvc.Scripts.Signals;

namespace TodoListApp.Actions
{
    public class RemoveTaskAction<ITaskInfo> : ASignal<ITaskInfo> { }
}