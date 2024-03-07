using System;

namespace Core
{
    public class Author
    {
        public Author(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
    }
}
