using Mvc.Scripts.Installers;
using TodoListApp.Actions;
using TodoListApp.Controllers;
using TodoListApp.Models;
using TodoListApp.Models.Interfaces;
using TodoListApp.Notifications;
using UnityEngine;

namespace TodoListApp.Installers
{
    [CreateAssetMenu(fileName = "TodoListInstaller", menuName = "ScriptableObjects/TodoListInstaller", order = 1)]
    public class TodoListInstaller : Installer
    {
        protected override void Install()
        {
            InstallModels();
            InstallNotifications();
            InstallActions();
        }

        private void InstallNotifications()
        {
            InstallNotification<ShowImageNotification>();
            InstallNotification<ShowEditPopupNotification>();
            InstallNotification<CloseEditPopupNotification>();
            InstallNotification<CloseDeletePopupNotification>();
            InstallNotification<ShowNotValidTaskNotification>();
            InstallNotification<ShowDeletePopupNotification<ITaskInfo>, ITaskInfo>();
            InstallNotification<AddTaskNotification<ITaskInfo>, ITaskInfo>();
            InstallNotification<RemoveTaskNotification, int>();
        }

        private void InstallActions()
        {
            InstallAction<ShowImageAction<APoco>, ShowImageController<APoco>, APoco>();
            InstallAction<ShowPopupAction, ShowEditPopupController>();
            InstallAction<ClosePopupAction, CloseEditPopupController>();
            InstallAction<CloseDeletePopupAction, CloseDeletePopupController>();
            InstallAction<ShowNotValidTaskAction, ShowNotValidTaskController>();
            InstallAction<CloseNotValidTaskAction, CloseNotValidTaskController>();
            InstallAction<ShowDeletePopupAction<ITaskInfo>, ShowDeletePopupController, ITaskInfo>();
            InstallAction<RemoveTaskAction<ITaskInfo>, RemoveTaskController, ITaskInfo>();
            InstallAction<AddTaskListAction<ITaskInfo>, AddTaskController, ITaskInfo>();
            InstallAction<SaveTaskAction<ITaskInfo>, SaveTaskController, ITaskInfo>();
        }

        private void InstallModels()
        {
            InstallModel<IImageModel>();
            InstallModel<IEditPopupModel>();
            InstallModel<ITodoListModel>();
            InstallModel<IDeletePopupModel>();
            InstallModel<INotValidTaskModel>();
        }

        public override void Uninstall()
        {
            UninstallSignals();
            UninstallModels();
        }
    }
}