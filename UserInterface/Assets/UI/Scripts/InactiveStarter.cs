using System.Collections.Generic;
using System.Linq;
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
        private void OnValidate()
        {
            var components= new List<InactiveStarter>();
            components.AddRange(GetComponentsInChildren<InactiveStarter>());
            components.AddRange(GetComponentsInParent<InactiveStarter>());
            components = components.Distinct().ToList();
            if (components.Count > 1)
            {
                Debug.LogWarning("There is already an Inactive starter in the hierarchy. " +
                                 "An inactive starter triggers Inactive Start in all child objects. " +
                                 "Therefore, you may have errors if there are more than 1.\n" +
                                 "The following components have Inactive Starter :\n\n" +
                                 string.Join("\n", components.Select(c => c.gameObject.name)) +
                                 "\n\n");
            }
        }
    }
}