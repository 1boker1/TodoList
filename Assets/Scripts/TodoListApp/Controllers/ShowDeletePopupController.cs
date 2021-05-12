using Mvc.Scripts.Controllers;
using TodoListApp.Installers;
using TodoListApp.Models.Interfaces;

namespace TodoListApp.Controllers
{
    public class ShowDeletePopupController : Controller<ITaskInfo>
    {
        public override void Execute(ITaskInfo task)
        {
            IDeletePopupModel model = GetModel<IDeletePopupModel>();
            
            model.ShowPopup(task);
        }
    }
}