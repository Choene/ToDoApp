using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Context;
using ToDoApp.Data.Models;

namespace ToDoApp.Data.Services
{
    public class TodoService
    {
        private readonly TodoDbContext _context;

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAll(string? searchTerm = null)
        {
            var query = _context.Todos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(t =>
                    t.Title.Contains(searchTerm) ||
                    (t.TodoDescription != null && t.TodoDescription.Contains(searchTerm))
                );
            }

            return await query.ToListAsync();
        }

        public async Task<TodoItem> Add(TodoItem todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task Update(TodoItem todo)
        {
            var existing = await _context.Todos.FindAsync(todo.Id);
            if (existing != null)
            {
                existing.Title = todo.Title;
                existing.TodoDescription = todo.TodoDescription;
                existing.IsCompleted = todo.IsCompleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ToggleComplete(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
