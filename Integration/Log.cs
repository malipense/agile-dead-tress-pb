using System;

namespace Integration
{
    internal class Log
    {
        public Log(string message, object obj)
        {
            EventId = Guid.NewGuid();
            Message = message;
            Object = obj;
        }
        public Log(string message)
        {
            EventId = Guid.NewGuid();
            Message = message;
        }

        public Guid EventId { get; private set; }
        public string Message { get; private set; }
        public object? Object { get; private set; }
        public DateTime EventDateTime => DateTime.Now;
    }
}
