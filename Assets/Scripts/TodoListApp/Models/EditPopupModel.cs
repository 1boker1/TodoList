using System.Collections.Generic;
using Mvc.Scripts.Models;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;

namespace TodoListApp.Models
{
    public class EditPopupModel : Notifier, IEditPopupModel
    {
        public void ShowPopup()
        {
            SendNotification<ShowEditPopupNotification>();
        }
        public void ClosePopup()
        {
            SendNotification<CloseEditPopupNotification>();
        }
    }
}