using UI.Abstraction;
using UnityEngine;

namespace UI.Switchers
{
    public class ActiveSwitcher : MonoBehaviour, IUISwitcher
    {
        public void Disappear() => gameObject.SetActive(false);
        public void Appear() => gameObject.SetActive(true);
    }
}