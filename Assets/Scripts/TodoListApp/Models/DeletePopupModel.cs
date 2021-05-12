using Mvc.Scripts.Models;
using TodoListApp.Installers;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;

namespace TodoListApp.Models
{
    public class DeletePopupModel : Notifier, IDeletePopupModel
    {
        public bool Enabled { get; private set; }

        public void ShowPopup(ITaskInfo task)
        {
            Enabled = true;

            SendNotification<ShowDeletePopupNotification<ITaskInfo>, ITaskInfo>(task);
        }

        public void ClosePopup()
        {
            Enabled = false;

            SendNotification<CloseDeletePopupNotification>();
        }
    }
}