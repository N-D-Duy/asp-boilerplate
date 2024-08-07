using ASPCleanArchitechture.Domain.Entities;

namespace ASPCleanArchitechture.Domain.DomainServices
{
    public interface ITodoService
    {
        Task MarkTodoAsCompleted(int todoId);
        Task<IEnumerable<Todo>> GetTodos();

        Task<Todo> CreateTodo(Todo todo); 

    }
}
