using System.Data;

namespace Company.Functions
{
    public static class BlobTriggerCSharp
    {
        [FunctionName("BlobTriggerCSharp")]
        public static void Run(
        [EventGridTrigger] EventGridEvent eventGridEvent,
        [Blob("{data.url}", FileAccess.Read, ConnectionState = "ImagesBlobStorage")] Stream imageBlob,
        [CosmosDB(databaseName: "GIS", collectionName: "Processed_images", ConnectionStringSetting = "CosmosDBConnection")] out dynamic document,
        [SignalR(HubName = "notifications")] IAsyncCollector<SignalRMessage> signalRMessages,
        ILogger log)
        {
            document = new { Description = eventGridEvent.Topic, Id = Guid.NewGuid() };
            log.LogInformation($"C# Blob trigger function Processed event\n Topic:{eventGridEvent.Topic} \n Subject: {eventGridEvent.Subject}");

            return signalRMessages.AddAsync(
                   new SignalRMessage
                   {
                       Target = "newMessage",
                       Arguments = new[] { document }
                   });
        }


    }
}