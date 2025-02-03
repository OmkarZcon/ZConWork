using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureBlobStorage
{
    public class AzureBlob
    {
        private readonly string _blobConnectionString;
        private const string ContainerName = "property-images";

        public AzureBlob(IConfiguration configuration)
        {
            _blobConnectionString = configuration["AzureBlobStorage:ConnectionString"];
        }

        [FunctionName("UploadPropertyImage")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("UploadPropertyImage function started.");

            // Check if the request contains a file
            var formFile = req.Form.Files["file"];
            if (formFile == null || formFile.Length == 0)
            {
                return new BadRequestObjectResult("Please provide a valid file.");
            }

            
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

            // Create the blob container client
            BlobContainerClient containerClient = new BlobContainerClient(_blobConnectionString, ContainerName);
            await containerClient.CreateIfNotExistsAsync();

            // Upload the file to Blob storage
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            using (var stream = formFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }

            // Return the blob URL as a response
            string blobUrl = blobClient.Uri.ToString();
            return new OkObjectResult(new { BlobUrl = blobUrl });
        }
    }
    }
