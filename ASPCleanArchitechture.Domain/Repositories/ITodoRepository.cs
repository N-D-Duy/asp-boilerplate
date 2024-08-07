using ASPCleanArchitechture.Domain.Entities;

namespace ASPCleanArchitechture.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodos();
        Task<Todo?> GetTodoById(int id);
        Task<Todo> Create(Todo todo);
        Task<Todo> Update(Todo todo);
        Task<Todo> Delete(int id);
    }
}
