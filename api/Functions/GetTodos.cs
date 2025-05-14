//using AzureBackendApp.Models;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;

//[FunctionName("GetTodos")]
//public async Task<IActionResult> Run(
//    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todo")] HttpRequest req,
//    [Inject] ICrudService<TodoItem> todoService,
//    ILogger log)
//{
//    var todos = await todoService.GetAllAsync();
//    return new OkObjectResult(todos);
//}
