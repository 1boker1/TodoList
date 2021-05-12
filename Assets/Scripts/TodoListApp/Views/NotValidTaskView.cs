using System.Collections;
using Mvc.Scripts.Views;
using TodoListApp.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace TodoListApp.Views
{
    public class NotValidTaskView : View
    {
        [SerializeField]
        private GameObject _popup;

        [SerializeField]
        private int _secondsToHide;

        private void ShowPopup()
        {
            _popup.SetActive(true);

            StartCoroutine(WaitToClose());
        }

        IEnumerator WaitToClose()
        {
            yield return new WaitForSeconds(_secondsToHide);

            ClosePopup();
        }

        private void ClosePopup()
        {
            _popup.SetActive(false);
        }

        private void Start()
        {
            AddSignalLister<ShowNotValidTaskNotification>(ShowPopup);
        }

        private void OnDestroy()
        {
            RemoveSignalListener<ShowNotValidTaskNotification>(ShowPopup);
        }
    }
}