using ASPCleanArchitechture.Domain.Entities;
using ASPCleanArchitechture.Domain.Repositories;
using ASPCleanArchitechture.Infrastructure.ORM;
using Microsoft.EntityFrameworkCore;

namespace ASPCleanArchitechture.Infrastructure.Repositories
{
    public class TodoRepository: ITodoRepository
    {
        private readonly DatabaseContext _context;

        public TodoRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _context.Todos.ToListAsync();

        }

        public async Task<Todo?> GetTodoById(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Todo> Create(Todo todo)
        {
            var result = await _context.Todos.AddAsync(todo); // AddAsync là phương thức bất đồng bộ
            await _context.SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
            return result.Entity; // Trả về thực thể đã được thêm
        }

        public async Task<Todo> Update(Todo todo)
        {
            var result = _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Todo> Delete(int id)
        {
            var todo = await GetTodoById(id);
            if (todo == null)
            {
                return null; // Hoặc ném ra một ngoại lệ, tuỳ vào cách bạn muốn xử lý
            }

            var result = _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
