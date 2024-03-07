using Azure.Storage.Blobs;
using Core;
using System.Text;
using System.Text.Json;

namespace Integration.Handlers
{
    public class LogEventHandler : IObserver<Book>
    {
        private IDisposable _unsubscriber;
        private BlobServiceClient _blobServiceClient;

        public LogEventHandler()
        {
            _blobServiceClient = new BlobServiceClient("");
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
            Log log = new Log(error.Message);
            string json = JsonSerializer.Serialize(new Log(error.Message));
            var logContainer = _blobServiceClient.GetBlobContainerClient("agile-dead-logs");
           
            logContainer.UploadBlob(log.EventId.ToString(), new BinaryData(Encoding.UTF8.GetBytes(json)));
        }

        public void OnNext(Book value)
        {
            Log log = new Log("Entity updated: ", value);
            var json = JsonSerializer.Serialize(value);
            var logContainer = _blobServiceClient.GetBlobContainerClient("agile-dead-logs");
           
            logContainer.UploadBlob(log.EventId.ToString(), new BinaryData(Encoding.UTF8.GetBytes(json)));
        }
    }
}
