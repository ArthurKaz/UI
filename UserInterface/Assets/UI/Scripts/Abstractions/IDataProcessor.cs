using System;

namespace UI.Abstraction
{
    public interface IDataProcessor<out T>
    {
        public event Action<T> ProcessedSuccessfully;
    }
}