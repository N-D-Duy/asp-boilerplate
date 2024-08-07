namespace ASPCleanArchitechture.Domain.DomainServices
{
    using ASPCleanArchitechture.Domain.Entities;
    using ASPCleanArchitechture.Domain.Repositories;
    using System.Threading.Tasks;

    public class TodoService(ITodoRepository todoRepository): ITodoService
    {
        private readonly ITodoRepository _todoRepository = todoRepository;

        public Task<Todo> CreateTodo(Todo todo)
        {
            return _todoRepository.Create(todo);
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _todoRepository.GetTodos();
        }

        public async Task MarkTodoAsCompleted(int todoId)
        {
            var todo = await _todoRepository.GetTodoById(todoId);
            if (todo != null)
            {
                todo.MarkAsCompleted();
                await _todoRepository.Update(todo);
            }
        }


    }
}