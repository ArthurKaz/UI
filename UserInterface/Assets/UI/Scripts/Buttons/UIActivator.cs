using UI.Abstraction;

namespace UI.Buttons
{
    public class UIActivator : ButtonClick
    {
        private IUserInterface _userInterface;
        private IUserInterface UserInterface => _userInterface ??= GetComponent<IUserInterface>();
        public override void HandleClick() => UserInterface.Show();
    }
}