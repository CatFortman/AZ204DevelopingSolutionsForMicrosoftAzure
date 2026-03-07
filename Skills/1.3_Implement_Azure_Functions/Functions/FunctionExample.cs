using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.EventGrid;
using Microsoft.Azure.Functions.Worker.Extensions.Storage.Blobs;
using Microsoft.Azure.Functions.Worker.Extensions.CosmosDB;
using Microsoft.Azure.Functions.Worker.Extensions.SignalRService;

using Azure.Messaging.EventGrid;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using Azure.Storage;
using System.Text.Json;

namespace Functions;

public class BlobEventProcessor
{
    private readonly ILogger _logger;

    public BlobEventProcessor(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<BlobEventProcessor>();
    }

    [Function("BlobEventProcessor")]
    public FunctionOutput Run(
            [EventGridTrigger] EventGridEvent eventGridEvent,
            [BlobInput("{data.url}", Connection = "ImagesBlobStorage")] Stream imageBlob)
    {
        var document = new
        {
            id = Guid.NewGuid(),
            description = eventGridEvent.Topic
        };

        _logger.LogInformation("Event processed: {topic}", eventGridEvent.Topic);

        return new FunctionOutput
        {
            CosmosDocument = document,
            SignalRMessage = new SignalRMessageAction("newMessage")
            {
                Arguments = new[] { document }
            }
        };
    }
}
public class FunctionOutput
{
    [CosmosDBOutput(
        databaseName: "GIS",
        containerName: "Processed_images",
        Connection = "CosmosDBConnection")]
    public object CosmosDocument { get; set; }

    [SignalROutput(HubName = "notifications")]
    public SignalRMessageAction SignalRMessage { get; set; }
}