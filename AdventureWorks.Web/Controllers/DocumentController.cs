using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AdventureWorks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly AzureSettings azureSettings;
        private readonly BlobContainerClient blobContainer;
        private readonly QueueClient queueClient;
        private readonly ILogger<DocumentController> logger;

        public DocumentController(IOptions<AzureSettings> azureSettingsOptions, ILogger<DocumentController> logger)
        {
            this.azureSettings = azureSettingsOptions.Value;

            blobContainer = new BlobServiceClient(this.azureSettings.ConnectionString)
                .GetBlobContainerClient(azureSettings.Blob);
            blobContainer.CreateIfNotExists();

            queueClient = new QueueServiceClient(this.azureSettings.ConnectionString)
                .GetQueueClient(azureSettings.Queue);
            queueClient.CreateIfNotExists();

            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetStatus()
        {
            logger.LogDebug("Health check endpoint has been called.");

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
        {
            // foreach (var file in files)
            {
                if (file.Length <= 0)
                {
                    logger.LogDebug("No file is found during the file upload!");
                    return BadRequest();
                }

                using (var stream = file.OpenReadStream())
                {
                    logger.LogDebug("Taking file into a stream");

                    var blobClient = blobContainer.GetBlobClient(file.FileName);
                    blobClient.Upload(stream);

                    var blobFileLocation = blobClient.Uri.ToString();
                    var fileName = file.FileName;
                    var message = $"The file {fileName} has been uploaded on the next location - {blobFileLocation}";

                    logger.LogDebug(message);
                    queueClient.SendMessage(message);
                }
            }

            return Ok();
        }
    }
}