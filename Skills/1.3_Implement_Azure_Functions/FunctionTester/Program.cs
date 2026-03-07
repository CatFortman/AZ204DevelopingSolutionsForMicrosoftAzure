using Azure.Messaging.EventGrid;
using Functions;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var function = new BlobEventProcessor(loggerFactory);

var evt = new EventGridEvent(
    "test-id",
    "Microsoft.Storage.BlobCreated",
    "/blobServices/default/containers/images/blobs/sample.jpg",
    "1.0",
    new { url = "http://127.0.0.1:10000/devstoreaccount1/images/sample.jpg" }
);

await function.Run(evt);