using Mvc.Scripts.Models;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;

namespace TodoListApp.Models
{
    public class ImageModel : Notifier, IImageModel
    {
        public void ShowImage()
        {
            SendNotification<ShowImageNotification>();
        }
    }
}