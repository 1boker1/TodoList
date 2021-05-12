using Mvc.Scripts.Controllers;
using TodoListApp.Models.Interfaces;

namespace TodoListApp.Controllers
{
    public class ShowImageController<APoco> : Controller<APoco>
    {
        public override void Execute(APoco poco)
        {
            IImageModel model = GetModel<IImageModel>();
            model.ShowImage();
        }
    }
}