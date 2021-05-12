using Mvc.Scripts.Models.Interfaces;
using TodoListApp.Installers;

namespace TodoListApp.Models.Interfaces
{
    public interface ITodoListModel : IModel
    {
        void AddNewTask(ITaskInfo newTask);
        void DeleteTask(int id);
        void SaveTask(ITaskInfo newTask);
    }
}