using System;
using System.Collections.Generic;
using Mvc.Scripts.Views;
using TodoListApp.Installers;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;
using UnityEngine;

namespace TodoListApp.Views
{
    public class TodoListView : View
    {
        [SerializeField]
        private Transform _content;

        [SerializeField]
        private TaskView _taskPrefab;
        
        private Dictionary<int, TaskView> _tasks = new Dictionary<int, TaskView>();

        private void Start()
        {
            AddSignalLister<AddTaskNotification<ITaskInfo>, ITaskInfo>(AddNewTask);
            AddSignalLister<RemoveTaskNotification, int>(RemoveTask);
        }

        private void AddNewTask(ITaskInfo taskInfo)
        {
            TaskView newTask = Instantiate(_taskPrefab, _content);

            newTask.Initialize(taskInfo);
            
            _tasks.Add(taskInfo.Id, newTask);
        }

        private void RemoveTask(int id)
        {
            Destroy(_tasks[id].gameObject);
        }
        
        private void OnDestroy()
        {
            RemoveSignalListener<AddTaskNotification<ITaskInfo>, ITaskInfo>(AddNewTask);
            RemoveSignalListener<RemoveTaskNotification, int>(RemoveTask);;
        }
    }
}