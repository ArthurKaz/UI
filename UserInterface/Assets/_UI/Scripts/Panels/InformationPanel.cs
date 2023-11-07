using UI.Abstraction;

namespace UI.Panels
{
    public abstract class InformationPanel<T> : Panel, IDataRecipient<T>
    {
        public virtual void Show(T info)
        {
            Receive(info);
            Show();
        }
        public abstract void Receive(T t);
    }
}