using UI.Abstraction;
using UnityEngine;

namespace UI.Switchers.ColorChanger
{
    public abstract class BaseColorChanger<T> : MonoBehaviour, IColorChanger, IInactiveStart
    {
        protected T ToChangeColor;
        protected float InitialAlpha;
        public  void InactiveStart()
        {
            ToChangeColor = GetComponent<T>();
            InitialAlpha = GetInitialAlpha();
        }

        protected abstract float GetInitialAlpha();
        public abstract void ChangeAlpha(float percent);
    }
}