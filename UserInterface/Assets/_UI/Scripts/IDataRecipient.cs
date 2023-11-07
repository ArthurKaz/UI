namespace UI.Abstraction
{
    public interface IDataRecipient<in T>
    {
        public void Receive(T t);
    }
}