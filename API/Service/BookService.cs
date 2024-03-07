using API.Repository;
using API.ViewModels;
using Core;
using Integration;
using Integration.Handlers;

namespace API.Service
{
    public class BookService : IBookService
    {
        private IEventProvider<Book> _provider;
        private IRepository _repository;
        public BookService(IEventProvider<Book> provider, IRepository repository)
        {
            _provider = provider ?? throw new ArgumentNullException();
            _repository = repository ?? throw new ArgumentNullException();
        }
        public void Create()
        {

        }

        public void Publish(Guid bookId)
        {
            _provider.Subscribe(new LogEventHandler());

            var book = _repository.TryGetBook(bookId);
            if (book is not null)
            {
                book.Beta = true;
                _provider.Publish(book);
                _repository.Write();
            }
            else
            {
                _provider.Error("Could not find the specified book");
            }

            _provider.Complete();
        }

        public void AddChapter(Guid bookId, ChapterViewModel chapterViewModel)
        {
            _provider.Subscribe(new NotifyPublisherEventHandler());
            _provider.Subscribe(new LogEventHandler());

            Chapter chapter = new Chapter();

            var book = _repository.TryGetBook(bookId);

            if (book is not null)
            {
                book.Chapters.Add(chapter);
                _provider.Publish(book);
                _repository.Write();
            }
            else
            {
                _provider.Error("Could not find the specified book");
            }

            _provider.Complete();
        }
    }
}
