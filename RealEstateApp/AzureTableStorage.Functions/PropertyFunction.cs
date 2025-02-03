using System.Text.Json;
using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AzureTableStorage.Functions
{
    public class Program
    {
        private readonly TableClient _tableClient;
        private readonly ILogger<Program> _logger;

       
        public Program(TableClient tableClient, ILogger<Program> logger)
        {
            _tableClient = tableClient;
            _logger = logger;
        }

       
        [Function("CreatePropertyFunction")]
        public async Task<HttpResponseData> CreateProperty(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "properties")] HttpRequestData req,
            FunctionContext context)
        {
            _logger.LogInformation("Processing property creation request...");

            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var propertyEntity = JsonSerializer.Deserialize<PropertyEntity>(requestBody);

                if (propertyEntity == null)
                {
                    _logger.LogWarning("Invalid property data received.");

                    var badRequestResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badRequestResponse.WriteStringAsync("Invalid property data.");
                    return badRequestResponse;
                }

              
                await _tableClient.AddEntityAsync(propertyEntity);

              
                var response = req.CreateResponse(HttpStatusCode.Created);
                await response.WriteStringAsync("Property added successfully.");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred while processing the property: {ex.Message}") ;
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("An error occurred while processing the request.");
                return errorResponse;
            }
        }

      
        [Function("GetPropertiesFunction")]
        public async Task<HttpResponseData> GetProperties(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "properties/{partitionKey}")] HttpRequestData req,
            string partitionKey,
            FunctionContext context)
        {
            _logger.LogInformation($"Fetching properties for partition key: {partitionKey}");

            try
            {
               
                var properties = _tableClient.QueryAsync<PropertyEntity>(x => x.PartitionKey == partitionKey);

                var propertiesList = new List<PropertyEntity>();
                await foreach (var property in properties)
                {
                    propertiesList.Add(property);
                }

               
                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(propertiesList);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred while retrieving properties: {ex.Message}");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("An error occurred while retrieving the properties.");
                return errorResponse;
            }
        }

    }
}
