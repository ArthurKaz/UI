using UnityEngine;
using Color = UnityEngine.Color ;

namespace UI.Panels.Crafter
{
    public class ShapeData
    {
        public Color Color { get; private set; }
        public GameObject Figure { get; private set; }
        public readonly string Name;
        
        public ShapeData(string name, Color color, GameObject figure)
        {
            Name = name;
            Color = color;
            Figure = figure;
        }
    }
}