using UnityEngine;
using UnityEngine.UI;

namespace UI.Switchers.ColorChanger
{
    [RequireComponent(typeof(Image))]
    public class ImageColorChanger : BaseColorChanger<Image>
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