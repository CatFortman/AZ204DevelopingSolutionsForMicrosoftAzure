## Prerequisites
1. Azurite
2. CosmosDB Emulator
3. Azure Functions Core Tools

## Step 1
Identify triggers, input  bindings, outut bindings 
<br>*[Supported Bindings](https://learn.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings?tabs=isolated-process%2Cnode-v4%2Cpython-v2&pivots=programming-language-csharp)*
1.Run the following command to initialize a functions project
`func init --worker-runtime dotnet-isolated` 
2.Use decorators for functions and parameters. *See BlobTriggerCSharp function in FunctionExample.cs*
3. Download Azurite
4. Set Azurite file location
    * Open File → Preferences → Settings
    * Search for “Azurite: Location”
    * Set it to `.azurite`
5. Set local.settings.json:
    ``` 
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "ImagesBlobStorage": "UseDevelopmentStorage=true",
    "CosmosDBConnection": "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf...==;",
    "AzureSignalRConnectionString": "UseDevelopmentStorage=true" 
    ```
6. Download the Azure CosmosDB emulator and launch the emulator
7. Create a new blob storage container in Azurite named 'images' 
8. Open the Command Palette (Ctrl + Shift + P). Type “Azurite: Start” → press Enter.
9. Add a test image to the container
10 Ensure you are in the root directory and run the following commands:
`dotnet build 1.3_Implement_Azure_Functions.sln`
``
 to test the function:
    ```
    func eventgrid publish \
    --topic-endpoint http://localhost:7071/runtime/webhooks/EventGrid?functionName=BlobTriggerCSharp \
    --event sample-event.json
    ```
 

