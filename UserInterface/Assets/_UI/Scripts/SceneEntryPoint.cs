using System.Collections;
using System.Collections.Generic;
using UI.Abstraction;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public sealed class SceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private bool _inactiveStart;
        [SerializeField] private Canvas _canvas;
        private GameObject _root;

        public List<Transform> tochange = new List<Transform>();
        //important - for better performance put the Scene EntryPoint at the root of all components
        /*private IEnumerator Start()
        {
            DontDestroyOnLoad(_canvas);
            _root = new GameObject();
            _root.name = "Root";

            List<Transform> components = new List<Transform>();
            components.AddRange(FindObjectsOfType<Transform>(true));
            for (var index = 0; index < components.Count; index++)
            {
                var component = components[index];
                if (component.parent == null)
                {
                    tochange.Add(component.transform);
                }
                
            }

            if (_inactiveStart)
            {
                InactiveStart();
            }

            float t = 0;
            while (t < 4)
            {
                t += Time.deltaTime;
                yield return null;
            }
           
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }*/


        private void InactiveStart()
        {
            foreach (var change in tochange)
            {
                var inactiveStarts = change.GetComponentsInChildren<IInactiveStart>(true);
                foreach (var start in inactiveStarts)
                {
                    start.InactiveStart();
                }
            }
        }
    }
}