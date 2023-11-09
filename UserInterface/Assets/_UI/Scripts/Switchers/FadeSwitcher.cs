using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.Abstraction;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Switchers
{
    public class FadeSwitcher : MonoBehaviour, IUISwitcher, IInactiveStart
    {
        [SerializeField] private float _animationDuration;
        private ObjectsForFade _objectsForFade;
        public void InactiveStart()
        {
            _objectsForFade = new ObjectsForFade(gameObject);
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
                _objectsForFade.ChangeAlpha(percentageComplete);

                yield return null;
            }
            if (hiding)
            {
                gameObject.SetActive(false);
            }
        }
        
        private sealed class ObjectsForFade
        {
            private readonly List<Image> _images  = new();
            private readonly List<TextMeshProUGUI> _textMeshProUIs = new();

            public ObjectsForFade(GameObject root)
            {
                var images = root.GetComponentsInChildren<Image>();
                var texts =  root.GetComponentsInChildren<TextMeshProUGUI>();
                _images.AddRange(images);
                _textMeshProUIs.AddRange(texts);
                
            }
            public void ChangeAlpha(float alpha)
            {
                alpha = Mathf.Clamp01(alpha);
                foreach (var image in _images)
                {
                    var color = image.color;
                    color.a = alpha;
                    image.color = color;
                }

                foreach (var text in _textMeshProUIs)
                {
                    var color = text.color;
                    color.a = alpha;
                    text.color = color;
                }
            }
        }
    }
}