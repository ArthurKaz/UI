using TMPro;
using UnityEngine;

namespace UI.Switchers.ColorChanger
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextColorChanger : BaseColorChanger<TextMeshProUGUI>
    {
        protected override float GetInitialAlpha()
        {
            return ToChangeColor.color.a;
        }

        public override void ChangeAlpha(float percent)
        {
            var color = ToChangeColor.color;
            color.a = percent * InitialAlpha;
            ToChangeColor.color = color;
        }
    }
}