
using Core;

namespace Integration
{
    public interface IEventProvider<T>
    {
        public IDisposable Subscribe(IObserver<T> observer);
        public void Publish(T book);
        public void Error(string message);
        public void Complete();
    }
}
