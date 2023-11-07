using UI.Abstraction;
using UnityEngine;

namespace UI.Scripts
{
    public class InactiveStarter : MonoBehaviour
    {
        private void Start()
        {
            StartInactiveInChildren();
        }

        private void StartInactiveInChildren()
        {
            var inactiveStarts = GetComponentsInChildren<IInactiveStart>(true);
            
            foreach (var start in inactiveStarts)
            {
                start.InactiveStart();
            }
        }
    }
}