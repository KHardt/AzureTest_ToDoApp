//using AzureBackendApp.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;

//namespace YourNamespace.Functions.Todo
//{
//    public class GetTodos
//    {
//        private readonly ICrudService<TodoItem> _todoService;

//        public GetTodos(ICrudService<TodoItem> todoService)
//        {
//            _todoService = todoService;
//        }

//        [FunctionName("GetTodos")]
//        public async Task<IActionResult> Run(
//            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todo")] HttpRequest req,
//            ILogger log)
//        {
//            var todos = await _todoService.GetAllAsync();
//            return new OkObjectResult(todos);
//        }
//    }
//}
