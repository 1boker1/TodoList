using Mvc.Scripts.Signals;
using TodoListApp.Installers;

namespace TodoListApp.Notifications
{
    public class AddTaskListAction<ITaskInfo> : ASignal<ITaskInfo> { }
}