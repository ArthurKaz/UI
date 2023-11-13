using System.Collections;
using TMPro;
using UI.Abstraction;
using UI.Switchers.ColorChanger;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Switchers
{
    public class FadeSwitcher : MonoBehaviour, IUISwitcher, IInactiveStart
    {
        [SerializeField] private float _animationDuration;
        private IColorChanger[] _objectsForFade;

        public void InactiveStart()
        {
            _objectsForFade = GetComponentsInChildren<IColorChanger>();
        }

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

                ChangeAlpha(percentageComplete);

                yield return null;
            }

            if (hiding)
            {
                gameObject.SetActive(false);
            }
        }

        private void ChangeAlpha(float percent)
        {
            foreach (var objects in _objectsForFade)
            {
                objects.ChangeAlpha(percent);
            }
        }
        
        private void OnValidate()
        {
            var images = GetComponentsInChildren<Image>();
            var texts = GetComponentsInChildren<TextMeshProUGUI>();
            foreach (var image in images)
            {
                if (image.TryGetComponent<ImageColorChanger>(out _) == false)
                {
                    image.gameObject.AddComponent<ImageColorChanger>();
                }
            }

            foreach (var text in texts)
            {
                if (text.gameObject.TryGetComponent<TextColorChanger>(out _) == false)
                {
                    text.gameObject.AddComponent<ImageColorChanger>();
                }
            }
        }
    }
}