using UI.Panels;
using UnityEngine;

namespace UI.Example
{
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] private ShapeCreator _shapeCreator;
        [SerializeField] private YesNoQuestionnaire _yesNoQuestionnaire;
        [SerializeField] private Vector3 _pos;
        private GameObject _gameObject;
        public void Start()
        {
            _shapeCreator.ProcessedSuccessfully += Show;
            _yesNoQuestionnaire.ProcessedSuccessfully += Show;
        }

        private void Show(bool result)
        {
            var textRes = result ? "yes" : "no";
            Debug.Log($"Player pressed {textRes}");
        }

        private void Show(ShapeData shapeData)
        {
            if (_gameObject != null)
            {
                Destroy(_gameObject);
            }
            Debug.Log(shapeData.Name);
            _gameObject = Instantiate(shapeData.Figure, _pos, Quaternion.identity);
            _gameObject.GetComponent<MeshRenderer>().material.color = shapeData.Color;
            _gameObject.name = shapeData.Name;
        }
    }
}