using System;
using UI.Abstraction;

namespace UI.Panels
{
    public abstract class DataHandler<T0, T1> : Panel,  IDataRecipient<T0>,IDataProcessor<T1>
    {
        public event Action<T1> ProcessedSuccessfully;

        protected void OnProcessedSuccessfully(T1 t) => ProcessedSuccessfully?.Invoke(t);
        public abstract void Receive(T0 t);
    }
}