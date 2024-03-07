using Core;
using Azure.Messaging.ServiceBus;
using System.Text;
using System.Text.Json;
using System.Windows.Markup;

namespace Integration.Handlers
{
    public class NotifyPublisherEventHandler : IObserver<Book>
    {
        private IDisposable _unsubscriber;
        private ServiceBusClient _serviceBusClient;
        public NotifyPublisherEventHandler()
        {
            _serviceBusClient = new ServiceBusClient("",
                new ServiceBusClientOptions()
            {
                TransportType = ServiceBusTransportType.AmqpTcp
            });
        }
        public virtual void Subscribe(IObservable<Book> provider)
        {
            _unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber?.Dispose();
        }

        public void OnCompleted()
        {
            Unsubscribe();
        }

        public void OnError(Exception error)
        {

        }

        public void OnNext(Book value)
        {
            ServiceBusMessage message = new ServiceBusMessage(
                JsonSerializer.Serialize(new { 
                    authorId = value.Author.Id,
                    chapters = value.Chapters.FindAll(c => c.Reviewed == false),
                    date = DateTime.Now
                } ));

            string queue = "agile-dead-tree-queue";
            var sender = _serviceBusClient.CreateSender(queue);
            try
            {
                sender.SendMessageAsync(message);
            }
            catch(Exception e)
            {

            }
        }
    }
}
