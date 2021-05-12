using Mvc.Scripts.Controllers;
using TodoListApp.Models.Interfaces;

namespace TodoListApp.Controllers
{
    public class ShowNotValidTaskController : Controller
    {
        public override void Execute()
        {
            INotValidTaskModel model = GetModel<INotValidTaskModel>();
            model.ShowPopup();
        }
    }
}