using ASPCleanArchitechture.Domain.DomainServices;
using ASPCleanArchitechture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASPCleanArchitechture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet(Name = "GetTodos")]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _todoService.GetTodos();
            return Ok(todos);
        }

        [HttpPost("mark-as-completed", Name = "MarkTodoAsCompleted")]
        public async Task<IActionResult> MarkTodoAsCompleted(int todoId)
        {
            await _todoService.MarkTodoAsCompleted(todoId);
            return Ok();
        }

        [HttpPost("create", Name = "CreateTodo")]
        public async Task<IActionResult> CreateTodo(Todo todo)
        {
            var createdTodo = await _todoService.CreateTodo(todo);
            return CreatedAtRoute("GetTodos", createdTodo);
        }
    }
}
