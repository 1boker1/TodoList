using Mvc.Scripts.Controllers;
using TodoListApp.Models.Interfaces;

namespace TodoListApp.Controllers
{
    public class ShowEditPopupController : Controller
    {
        public override void Execute()
        {
            IEditPopupModel model = GetModel<IEditPopupModel>();
            model.ShowPopup();
        }
    }
}