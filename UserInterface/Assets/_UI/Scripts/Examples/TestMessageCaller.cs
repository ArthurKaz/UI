using System;
using UI.Panels;
using UnityEngine;

namespace UI.Buttons
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