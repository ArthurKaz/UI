using UI.Abstraction;
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
                Debug.LogError("The button is null, your method will not be called");
            }
            else
            {
                _button.onClick.AddListener(HandleClick);
            }
        }

        public abstract void HandleClick();
    }
}