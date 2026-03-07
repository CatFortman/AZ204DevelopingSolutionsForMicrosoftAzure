## Prerequisites
1. Azurite
2. CosmosDB Emulator
3. Azure Functions Core Tools

## Step 1
Identify triggers, input  bindings, outut bindings 
<br>*[Supported Bindings](https://learn.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings?tabs=isolated-process%2Cnode-v4%2Cpython-v2&pivots=programming-language-csharp)*
1. Run the following command to initialize a functions project
`func init --worker-runtime dotnet-isolated` 
2. Use decorators for functions and parameters. *See BlobEventProcessor function in FunctionExample.cs*

## Step 2
Download & setup dependencies 
1. Download Azurite
2. Set Azurite file location
    * Open File → Preferences → Settings
    * Search for “Azurite: Location”
    * Set it to `.azurite`
3. Set local.settings.json:
    ``` 
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "ImagesBlobStorage": "UseDevelopmentStorage=true",
    "CosmosDBConnection": "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf...==;",
    "AzureSignalRConnectionString": "UseDevelopmentStorage=true" 
    ```
4. Download the Azure CosmosDB emulator and launch the emulator
5. Create a new blob storage container in Azurite named 'images' 

## Step 3
Run the function app
1. Open the Command Palette (Ctrl + Shift + P). Type “Azurite: Start” → press Enter.
2. Add a test image to the container
3. Ensure you are in the root directory and run the following commands to start the function app:
    ```
    dotnet restore 1.3_Implement_Azure_Functions.sln
    dotnet build 1.3_Implement_Azure_Functions.sln
    dotnet run 1.3_Implement_Azure_Functions.sln
    ```
4. Run `func start 1.3_Implement_Azure_Functions.sln`
5. To test the function, run this command:
    ```
    Invoke-RestMethod -Method Post \
    -Uri "http://localhost:7071/runtime/webhooks/EventGrid?functionName=BlobEventProcessor" \
    -ContentType "application/json" \
    -InFile ".\sample-event.json"
    ```

Invoke-RestMethod -Method Post  -Uri "http://localhost:7071/runtime/webhooks/EventGrid?functionName=BlobEventProcessor"  -ContentType "application/json"  -InFile ".\sample-event.json"

$body = Get-Content ".\sample-event.json" -Raw
Invoke-RestMethod -Method Post  -Uri "http://localhost:7071/runtime/webhooks/EventGrid?functionName=BlobEventProcessor"  -ContentType "application/json"  -Body $body

dotnet new console -n FunctionTester -f net8.0