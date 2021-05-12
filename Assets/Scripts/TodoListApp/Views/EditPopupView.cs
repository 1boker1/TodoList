using Mvc.Scripts.Views;
using TodoListApp.Actions;
using TodoListApp.Installers;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace TodoListApp.Views
{
    public class EditPopupView : View
    {
        [SerializeField]
        private GameObject _editPopup;

        [Header("Buttons")]
        [SerializeField]
        private Button _saveButton;

        [SerializeField]
        private Button _deleteButton;

        [SerializeField]
        private Button _closeButton;

        [Header("Input fields")]
        [SerializeField]
        private InputField _title;

        [SerializeField]
        private InputField _description;

        private void SaveTask()
        {
            TaskInfo newTask = new TaskInfo(_title.text, _description.text);
            
            SendAction<SaveTaskAction<ITaskInfo>, ITaskInfo>(newTask);
        }

        private void Delete()
        {
            TaskInfo newTask = new TaskInfo(_title.text, _description.text);

            SendAction<ShowDeletePopupAction<ITaskInfo>, ITaskInfo>(newTask);
        }

        private void Close()
        {
            SendAction<ClosePopupAction>();
        }

        private void ResetInputFields()
        {
            _title.text = "";
            _description.text = "";
        }
        
        private void ShowPopup()
        {
            _editPopup.SetActive(true);
        }

        private void ClosePopup()
        {
            ResetInputFields();

            _editPopup.SetActive(false);
        }

        private void Start()
        {
            AddSignalLister<ShowEditPopupNotification>(ShowPopup);
            AddSignalLister<CloseEditPopupNotification>(ClosePopup);

            _saveButton.onClick.AddListener(SaveTask);
            _deleteButton.onClick.AddListener(Delete);
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            RemoveSignalListener<ShowEditPopupNotification>(ShowPopup);
            RemoveSignalListener<CloseEditPopupNotification>(ClosePopup);

            _saveButton.onClick.RemoveListener(SaveTask);
            _deleteButton.onClick.RemoveListener(Delete);
            _closeButton.onClick.RemoveListener(Close);
        }
    }
}