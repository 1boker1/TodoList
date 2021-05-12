using Mvc.Scripts.Controllers;
using TodoListApp.Models.Interfaces;

namespace TodoListApp.Controllers
{
    public class CloseDeletePopupController : Controller
    {
        public override void Execute()
        {
            IDeletePopupModel model = GetModel<IDeletePopupModel>();
            model.ClosePopup();
        }
    }
}