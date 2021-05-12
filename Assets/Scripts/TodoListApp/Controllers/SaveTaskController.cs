using Mvc.Scripts.Controllers;
using TodoListApp.Models.Interfaces;

namespace TodoListApp.Controllers
{
    public class SaveTaskController : Controller<ITaskInfo>
    {
        public override void Execute(ITaskInfo task)
        {
            ITodoListModel model = GetModel<ITodoListModel>();
            
            model.SaveTask(task);
        }
    }
}