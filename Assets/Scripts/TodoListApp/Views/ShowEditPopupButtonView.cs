using Mvc.Scripts.Views;
using TodoListApp.Actions;
using TodoListApp.Installers;
using UnityEngine;
using UnityEngine.UI;

namespace TodoListApp.Views
{
    public class ShowEditPopupButtonView : View
    {
        [SerializeField]
        private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(ShowEditPopup);
        }

        private void ShowEditPopup()
        {
            SendAction<ShowPopupAction>();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ShowEditPopup);
        }
    }
}