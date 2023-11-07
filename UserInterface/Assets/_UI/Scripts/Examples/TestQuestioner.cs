using UI.Buttons;
using UI.Panels;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Scripts.Examples
{
    public class TestQuestioner : ButtonClick
    {
        [SerializeField] private YesNoQuestionnaire _yesNoQuestionnaire;
        public override void HandleClick()
        {
            _yesNoQuestionnaire.AskQuestion("Press yes or no");
        }
    }
}