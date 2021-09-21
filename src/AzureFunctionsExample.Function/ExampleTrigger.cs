using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsExample.Function
{
    public static class ExampleTrigger
    {

        [Function("ExampleTrigger")]
        public static HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            [CosmosDB(databaseName: "my-database", collectionName: "my-container", ConnectionStringSetting = "CosmosDB")] IAsyncCollector<dynamic> documents,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("ExampleTrigger");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
