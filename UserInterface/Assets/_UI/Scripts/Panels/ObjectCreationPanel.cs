using System;
using UI.Abstraction;

namespace UI.Panels
{
    public abstract class ObjectCreationPanel<T> : Panel, IDataProcessor<T>
    {
        public event Action<T> ProcessedSuccessfully;
        protected void OnProcessedSuccessfully(T t) => ProcessedSuccessfully?.Invoke(t);
    }
}