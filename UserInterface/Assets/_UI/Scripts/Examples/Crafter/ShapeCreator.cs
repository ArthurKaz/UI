using System;
using TMPro;
using UI.Panels;
using UI.Switchers.ColorChanger;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

namespace UI.Example
{
    public sealed class ShapeCreator : ObjectCreationPanel<ShapeData>
    {
        [SerializeField] private TMP_Dropdown _color;
        [SerializeField] private TMP_Dropdown _figure;
        [SerializeField] private TMP_InputField _textMeshProUGUI;
        [SerializeField] private Button _create;

        [SerializeField] private GameObject _cube;
        [SerializeField] private GameObject _sphere;
        [SerializeField] private GameObject _cylinder;
        private void Awake()
        {
            _create.onClick.AddListener(CreateShape);
        }

        private void CreateShape()
        {
            var color = GetColor(_color.value);
            var figure = GetFigure(_figure.value);
            var name = _textMeshProUGUI.text;
            CreateShape(name, color, figure);
        }
        private void CreateShape(string name, Color color, GameObject gameObject)
        {
            var shape = new ShapeData(name, color, gameObject);
            OnProcessedSuccessfully(shape);
        }

        private Color GetColor(int index)
        {
            return index switch
            {
                0 => Color.red,
                1 => Color.blue,
                2 => Color.yellow,
                _ => Color.white
            };
        }

        private GameObject GetFigure(int index)
        {
            return index switch
            {
                0 => _cube,
                1 => _cylinder,
                2 => _sphere,
                _ => _cube
            };
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