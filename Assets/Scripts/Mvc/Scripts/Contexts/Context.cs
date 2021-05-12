using System;
using System.Collections.Generic;
using System.Linq;
using Mvc.Scripts.Installers;
using Mvc.Scripts.Models;
using Mvc.Scripts.Models.Interfaces;
using Mvc.Scripts.Signals;
using UnityEngine;

namespace Mvc.Scripts.Contexts
{
    public class Context : MonoBehaviour
    {
        [SerializeField] protected Installer[] _installers;

        private static Context _instance;
        public static Context Instance => _instance;
        
        public Dictionary<string, IModel> Models { get; private set; }
        public SignalHub SignalHub { get; private set; }

        public T GetModel<T>(string id = null) where T: class, IModel
        {
            Type interfaceType = typeof(T);
            Type implementationType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .FirstOrDefault(p => interfaceType.IsAssignableFrom(p) && !p.IsInterface);

            if (implementationType == null)
            {
                throw new Exception("This model interface is not implemented!");
            }
            
            string modelId = string.IsNullOrEmpty(id) ? implementationType.ToString() : id;

            if (Models.ContainsKey(modelId))
            {
                return Models[modelId] as T;
            }

            throw new Exception("Model not found");
        }

        public T GetSignal<T>() where T: ISignal, new()
        {
            return SignalHub.GetSignal<T>();
        }

        protected virtual void Awake()
        {
            Models = new Dictionary<string, IModel>();
            SignalHub = new SignalHub();
            
            _instance = this;
            
            DontDestroyOnLoad(this);
            
            Install();
        }

        private void Install()
        {
            for (int i = 0; i < _installers.Length; i++)
            {
                _installers[i].Install(SignalHub, Models);
            }
        }

        private void OnDestroy()
        {
            Uninstall();
        }

        private void Uninstall()
        {
            for (int i = 0; i < _installers.Length; i++)
            {
                _installers[i].Uninstall();
            }
        }
    }
}
