using System;
using UI.Buttons;
using UI.Panels;
using UnityEngine;

namespace UI.Example
{
    [Serializable]
    public class TestMessageCaller : ButtonClick
    {
        [SerializeField] private Message _messageBox;
        
        public override void HandleClick()
        {
            _messageBox.Show("Test message");
        }
    }
}