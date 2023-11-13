using System;
using UI.Abstraction;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public abstract class ButtonClick : MonoBehaviour, IClickHandler, IInactiveStart
    {
        [SerializeField] private Button _button;

        public void InactiveStart()
        {
            if (_button == null && TryGetComponent(out _button) == false)
            {
                Debug.LogError(name + " the button is null, your method will not be called");
            }
            else
            {
                _button.onClick.AddListener(HandleClick);
            }
        }

        public abstract void HandleClick();
        private void OnValidate()
        {
            if (_button == null && TryGetComponent(out Button button))
            {
                _button = button;
            }
            
        }
    }
}