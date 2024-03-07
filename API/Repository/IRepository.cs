using Core;

namespace API.Repository
{
    public interface IRepository
    {
        public Chapter? TryGetChapter(Guid bookId, Guid chapterId);
        public Book? TryGetBook(Guid bookId);
        public void Write();
    }
}
