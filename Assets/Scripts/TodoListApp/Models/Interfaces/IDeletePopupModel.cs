using Mvc.Scripts.Models.Interfaces;
using TodoListApp.Installers;

namespace TodoListApp.Models.Interfaces
{
    public interface IDeletePopupModel : IModel
    {
        bool Enabled { get; }
        void ShowPopup(ITaskInfo task);
        void ClosePopup();
    }
}