//using AzureBackendApp.Models;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;

//[FunctionName("DeleteTodo")]
//public async Task<IActionResult> Run(
//    [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "todo/{id}")] HttpRequest req,
//    string id,
//    [Inject] ICrudService<TodoItem> todoService,
//    ILogger log)
//{
//    await todoService.DeleteAsync(id);
//    return new OkResult();
//}
