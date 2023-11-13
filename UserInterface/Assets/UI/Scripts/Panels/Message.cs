using TMPro;
using UnityEngine;

namespace UI.Panels
{
    public sealed class Message : InformationPanel<string>
    {
        [SerializeField] private TextMeshProUGUI _text;
        

        public override void Receive(string t)
        {
            _text.text = t;
        }
    }
}