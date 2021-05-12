using Mvc.Scripts.Installers;
using UnityEngine;

namespace Mvc.Scripts.Contexts
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] protected Installer[] _installers;

        private void Awake()
        {
            for (int i = 0; i < _installers.Length; i++)
            {
                _installers[i].Install(Context.Instance.SignalHub, Context.Instance.Models);
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _installers.Length; i++)
            {
                _installers[i].Uninstall();
            }
        }
    }
}