using System.Collections.Generic;
using Mvc.Scripts.Models;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;

namespace TodoListApp.Models
{
    public class TodoListModel : Notifier, ITodoListModel
    {
        private int _idToAssign;

        private Dictionary<int, ITaskInfo> _tasks = new Dictionary<int, ITaskInfo>();

        public void AddNewTask(ITaskInfo task)
        {
            task.Id = _idToAssign;
            _tasks.Add(task.Id, task);
            _idToAssign++;

            SendNotification<AddTaskNotification<ITaskInfo>, ITaskInfo>(task);
        }

        public void DeleteTask(int id)
        {
            if (_tasks.ContainsKey(id))
            {
                _tasks.Remove(id);
                SendNotification<RemoveTaskNotification, int>(id);
            }
        }

        public void SaveTask(ITaskInfo task)
        {
            if (task.IsValidTask())
            {
                AddNewTask(task);
                SendNotification<CloseEditPopupNotification>();
            }
            else if (task.Description==null)
            {
                SendNotification<CloseEditPopupNotification>();
            }
            else
            {
                SendNotification<ShowNotValidTaskNotification>();
            }
        }
    }
}