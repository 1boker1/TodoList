using System;
using Mvc.Scripts.Views;
using TodoListApp.Actions;
using TodoListApp.Installers;
using UnityEngine;
using UnityEngine.UI;

namespace TodoListApp.Views
{
    public class ShowImageButtonView : View
    {
        [SerializeField] private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(ShowImage);
        }

        private void ShowImage()
        {
            APoco poco = new APoco();
            SendAction<ShowImageAction<APoco> ,APoco>(poco);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ShowImage);

        }
    }

}