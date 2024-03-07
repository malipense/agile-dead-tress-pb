using Core;

namespace Integration
{
    public class BookEventProvider : IObservable<Book>, IEventProvider<Book>
    {
        private readonly HashSet<IObserver<Book>> _observers = new();
        
        public BookEventProvider()
        {
        }

        public IDisposable Subscribe(IObserver<Book> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber<Book>(_observers, observer);
        }

        public void Publish(Book book)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(book);
            }
        }

        public void Error(string message)
        {
            foreach (var observer in _observers)
            {
                observer.OnError(new Exception(message));
            }
        }

        public void Complete()
        {
            _observers.Clear();
        }
    }

    public sealed class Unsubscriber<Book> : IDisposable
    {
        private readonly ISet<IObserver<Book>> _observers;
        private readonly IObserver<Book> _observer;

        internal Unsubscriber(
            ISet<IObserver<Book>> observers,
            IObserver<Book> observer) => (_observers, _observer) = (observers, observer);

        public void Dispose() => _observers.Remove(_observer);
    }
}
