using Mvc.Scripts.Models.Interfaces;

namespace TodoListApp.Models.Interfaces
{
    public interface IEditPopupModel : IModel
    {
        void ShowPopup();
        void ClosePopup();
    }
}