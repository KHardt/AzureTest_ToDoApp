using AzureBackendApp.Models;
using AzureBackendApp.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureBackendApp.Functions
{
    public class CreateTodo
    {
        private readonly ICrudService<TodoItem> _service;

        public CreateTodo(ICrudService<TodoItem> service)
        {
            _service = service;
        }

        [Function("CreateTodo")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "todos")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CreateTodo");

            var requestBody = await JsonSerializer.DeserializeAsync<TodoItem>(req.Body);
            var createdItem = await _service.CreateAsync(requestBody);

            var response = req.CreateResponse(HttpStatusCode.Created);
            await response.WriteAsJsonAsync(createdItem);
            return response;
        }
    }
}
