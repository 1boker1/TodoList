using Mvc.Scripts.Models;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;

namespace TodoListApp.Models
{
    public class NotValidTaskModel : Notifier, INotValidTaskModel
    {
        public void ShowPopup()
        {
            SendNotification<ShowNotValidTaskNotification>();
        }

        public void ClosePopup()
        {
            SendNotification<CloseNotValidTaskNotification>();
        }
    }
}