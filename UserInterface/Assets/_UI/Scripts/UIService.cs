using System;
using System.Collections.Generic;
using System.Linq;
using UI.Abstraction;
using UI.Panels;
using UnityEngine;

namespace UI.Scripts
{
    [RequireComponent(typeof(Canvas))]
    public abstract class UIService : MonoBehaviour
    {
        private Panel[] _panels;
        public YesNoQuestionnaire YesNoQuestionnaire { get; private set; }
        public Message Message{ get; private set; }
        
        private void Start()
        {
            Init();
            
        }

        protected virtual void Init()
        {
            _panels = GetComponentsInChildren<Panel>(true);
            Message = GetPanelOfType<Message>();
            YesNoQuestionnaire = GetPanelOfType<YesNoQuestionnaire>();
        }

        protected T GetPanelOfType<T>() where T : Panel
        {
            return _panels.OfType<T>().FirstOrDefault();
        }
        
       
    }
}