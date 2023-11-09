using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public sealed class YesNoQuestionnaire : DataHandler<string, bool>
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _yes;
        [SerializeField] private Button _no;

        private void Awake()
        {
            _yes.onClick.AddListener(HandleYes);
            _no.onClick.AddListener(HandleNo);
        }
        public void AskQuestion(string question)
        {
            Receive(question);
            Show();
        }
        public override void Receive(string t)
        {
            _text.text = t;
        }

        private void HandleYes() => OnProcessedSuccessfully(true);
        private void HandleNo() => OnProcessedSuccessfully(false);
        
    }
}