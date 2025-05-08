using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureBackendApp
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            var response = new { message = "Welcome to Azure Functions!" };
            var json = JsonSerializer.Serialize(response);

            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

    }
}
