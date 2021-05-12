using Mvc.Scripts.Controllers;
using TodoListApp.Installers;
using TodoListApp.Models.Interfaces;

namespace TodoListApp.Controllers
{
    public class AddTaskController :  Controller<ITaskInfo>
    {
        public override void Execute(ITaskInfo task)
        {
            ITodoListModel model = GetModel<ITodoListModel>();
            
            model.AddNewTask(task);
        }
    }
}