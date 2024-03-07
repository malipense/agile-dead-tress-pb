using System;

namespace Core
{
    public class Chapter
    {
        public Guid Id { get; private set; }
        public bool Reviewed { get; private set; }
        public List<Comment>? Comments { get; private set; }
    }

    public class Comment
    {
        public DateTime CreatedAt { get; private set; }
        public string? Content { get; private set; }
    }
}
