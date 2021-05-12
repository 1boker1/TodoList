using System;
using Mvc.Scripts.Views;
using TodoListApp.Actions;
using TodoListApp.Installers;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TodoListApp.Views
{
    public class TaskView : View
    {
        [SerializeField]
        private Text _title;

        [SerializeField]
        private Text _description;

        [SerializeField]
        private Button _button;

        private ITaskInfo _task;

        public void Initialize(ITaskInfo taskInfo)
        {
            _task = taskInfo;
            _title.text = taskInfo.Title;
            _description.text = taskInfo.Description;
        }

        private void OnTaskClicked()
        {
            SendAction<ShowDeletePopupAction<ITaskInfo>, ITaskInfo>(_task);
        }

        private void Start()
        {
            _button.onClick.AddListener(OnTaskClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnTaskClicked);
        }
    }
}