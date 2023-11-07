using System.Collections;
using UI.Abstraction;
using UnityEngine;

namespace UI.Animations
{
    public class ScaleSwitcher : MonoBehaviour, IUISwitcher
    {
        private static readonly Vector3 Hidden = Vector3.zero;
        private static readonly Vector3 Shown = Vector3.one;
        
        [SerializeField] private AnimationCurve _scaleCurve;
        [SerializeField] private float _animationDuration = 2.0f;
        public void Disappear()
        {
            StartCoroutine(PlayAnimation(true));
        }

        public void Appear()
        {
            gameObject.SetActive(true);
            StartCoroutine(PlayAnimation());
        }
        private IEnumerator PlayAnimation(bool hiding = false)
        {
            float time = 0;

            while (time <= _animationDuration)
            {
                time += Time.deltaTime;
                var percentageComplete = time / _animationDuration;
                if (hiding)
                {
                    percentageComplete = 1 - percentageComplete;
                }
                var scaleValue = _scaleCurve.Evaluate(percentageComplete);
                transform.localScale = Lerp(Hidden, Shown, scaleValue);

                yield return null;
            }
            if (hiding)
            {
                gameObject.SetActive(false);
            }
        }
        
        private static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
        }
    }
}