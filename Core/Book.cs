
namespace Core
{
    public class Book
    {
        public Book(Author author)
        {
            Id = Guid.NewGuid();
            Beta = false;
            Author = author;
            Chapters = new List<Chapter>();
        }
        public bool Beta { get; set; }
        public Guid Id { get; set; }
        public List<Chapter>? Chapters { get; set; }
        public Author? Author { get; private set; }
    }
}
