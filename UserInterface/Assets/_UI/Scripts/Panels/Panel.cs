using UnityEngine;
using UI.Abstraction;
namespace UI.Panels
{
    [RequireComponent(typeof(IUISwitcher))]
    public abstract class Panel : MonoBehaviour, IUserInterface
    {
        private IUISwitcher _switcher;
        private IUISwitcher Switcher => _switcher ??= GetComponent<IUISwitcher>();

        public virtual void Show()
        {
           Switcher.Appear();
        }

        public virtual void Hide()
        {
            Switcher.Disappear();
        }
    }
}