using System;
using Mvc.Scripts.Views;
using TodoListApp.Notifications;
using UnityEngine;

namespace TodoListApp.Views
{
    public class ImageView : View
    {
        [SerializeField] private GameObject _image;

        private void Start()
        {
            AddSignalLister<ShowImageNotification>(ShowImage);
        }

        private void ShowImage()
        {
            _image.SetActive(true);
        }

        private void OnDestroy()
        {
            RemoveSignalListener<ShowImageNotification>(ShowImage);
        }
    }
}