//using AzureBackendApp.Models;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;

//[FunctionName("UpdateTodo")]
//public async Task<IActionResult> Run(
//    [HttpTrigger(AuthorizationLevel.Function, "put", Route = "todo/{id}")] HttpRequest req,
//    string id,
//    [Inject] ICrudService<TodoItem> todoService,
//    ILogger log)
//{
//    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
//    var updatedTodo = JsonConvert.DeserializeObject<TodoItem>(requestBody);
//    updatedTodo.Id = id;

//    var result = await todoService.UpdateAsync(updatedTodo);
//    return new OkObjectResult(result);
//}
