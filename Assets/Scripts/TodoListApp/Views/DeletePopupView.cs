using Mvc.Scripts.Views;
using TodoListApp.Actions;
using TodoListApp.Installers;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace TodoListApp.Views
{
    public class DeletePopupView : View
    {
        [SerializeField]
        private GameObject _popup;

        [SerializeField]
        private Button _accept;

        [SerializeField]
        private Button _decline;

        [SerializeField]
        private Text _title;

        [SerializeField]
        private Text _description;

        private ITaskInfo _task;

        private void ShowPopup(ITaskInfo task)
        {
            _popup.SetActive(true);

            _task = task;
            _title.text = task.Title;
            _description.text= task.Description;
        }

        private void ClosePopup()
        {
            _popup.SetActive(false);
        }

        private void Start()
        {
            AddSignalLister<ShowDeletePopupNotification<ITaskInfo>, ITaskInfo>(ShowPopup);
            AddSignalLister<CloseDeletePopupNotification>(ClosePopup);
            _accept.onClick.AddListener(Accept);
            _decline.onClick.AddListener(Decline);
        }

        private void Decline()
        {
            SendAction<CloseDeletePopupAction>();
        }

        private void Accept()
        {
            SendAction<ClosePopupAction>();
            SendAction<CloseDeletePopupAction>();
            SendAction<RemoveTaskAction<ITaskInfo>, ITaskInfo>(_task);
        }

        private void OnDestroy()
        {
            RemoveSignalListener<ShowDeletePopupNotification<ITaskInfo>, ITaskInfo>(ShowPopup);
            RemoveSignalListener<CloseDeletePopupNotification>(ClosePopup);
            _accept.onClick.RemoveListener(Accept);
            _decline.onClick.RemoveListener(Decline);
        }
    }
}