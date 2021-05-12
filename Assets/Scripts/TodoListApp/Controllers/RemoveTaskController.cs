using Mvc.Scripts.Controllers;
using TodoListApp.Installers;
using TodoListApp.Models.Interfaces;

namespace TodoListApp.Controllers
{
    public class RemoveTaskController : Controller<ITaskInfo>
    {
        public override void Execute(ITaskInfo task)
        {
            ITodoListModel model = GetModel<ITodoListModel>();
            
            model.DeleteTask(task.Id);
        }
    }
}