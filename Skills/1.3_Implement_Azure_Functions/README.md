## Prerequisites
1. Azurite
2. CosmosDB Emulator
3. Azure Functions Core Tools

## Step 1
Identify triggers, input  binings, an outut bindings 
<br>*[Supported Bindings](../1.1_Provisioning_A_VM/README.md)*
1. Use decorators for functions and parameters. *See BlobTriggerCSharp function in FunctionExample.cs*
2. Download Azurite
3. Set Azurite file location
    * Open File → Preferences → Settings
    * Search for “Azurite: Location”
    * Set it to `.azurite`
4. Set local.settings.json:
    ``` 
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "ImagesBlobStorage": "UseDevelopmentStorage=true",
    "CosmosDBConnection": "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf...==;",
    "AzureSignalRConnectionString": "UseDevelopmentStorage=true" 
    ```
5. Download the Azure CosmosDB emulator and launch the emulator
6. Create a new blob storage container in Azurite named 'images' 
7. Open the Command Palette (Ctrl + Shift + P). Type “Azurite: Start” → press Enter.
8. Add a test image to the container
Run the following command to test the function:
    ```
    func eventgrid publish \
    --topic-endpoint http://localhost:7071/runtime/webhooks/EventGrid?functionName=BlobTriggerCSharp \
    --event sample-event.json
    ```
 

