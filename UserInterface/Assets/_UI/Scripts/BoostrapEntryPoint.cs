using System;
using UI.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace UI
{
    public class BoostrapEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIService _uiService;

        private void Start()
        {
            if (ServiceContainer.UIService == null)
            {
                ServiceContainer.UIService = _uiService;
                DontDestroyOnLoad(_uiService);
            }

            SceneManager.LoadScene(sceneBuildIndex: 1);
            
        }
    }
}