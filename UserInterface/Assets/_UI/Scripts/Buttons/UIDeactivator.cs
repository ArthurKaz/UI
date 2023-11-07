using UI.Abstraction;
using UnityEngine;

namespace UI.Buttons
{
    [RequireComponent(typeof(IUserInterface))]
    public class UIDeactivator : ButtonClick
    {
        private IUserInterface _userInterface;
        private IUserInterface UserInterface => _userInterface ??= GetComponent<IUserInterface>();
        public override void HandleClick() => UserInterface.Hide();
    }
}