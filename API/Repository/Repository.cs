using Core;

namespace API.Repository
{
    public class Repository : IRepository
    {
        private static List<Book> Books = new List<Book>()
        {
            new Book(new Author("Eduardo")),
            new Book(new Author("Roberto")),
            new Book(new Author("Carlos"))
        };
        public Chapter? TryGetChapter(Guid bookId, Guid chapterId)
        {
            var book = Books.FirstOrDefault(b => b.Id == bookId);
            if (book is not null)
                return book.Chapters.FirstOrDefault(c => c.Id == chapterId);

            return null;
        }

        public Book? TryGetBook(Guid bookId)
        {
            Books.First().Id = Guid.Parse("a9d80280-5472-4573-a1b4-e881449bfeae");
            return Books.FirstOrDefault(b => b.Id == bookId);
        }

        public void Write()
        {

        }
    }
}
