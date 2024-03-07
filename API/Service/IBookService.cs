using API.ViewModels;

namespace API.Service
{
    public interface IBookService
    {
        public void Create();
        public void Publish(Guid bookId);
        public void AddChapter(Guid bookId, ChapterViewModel chapter);
    }
}
