using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

namespace Todo.Infrastructure.Data
{
    public class InMemoryTodoTaskRepository : ITodoTaskRepository
    {
        // private readonly List<TodoTask> _todoTasks = new List<TodoTask>();
        private readonly TodoTaskDbContext _context;

        public InMemoryTodoTaskRepository(TodoTaskDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoTask>> GetAllTodoTasksAsync()
        {
            return await _context.TodoTasks.ToListAsync();
        }

        public async Task<TodoTask?> GetTodoTaskByIdAsync(int id)
        {
            //Task.FromResult(_todoTasks.SingleOrDefault(x => x.Id == id));
            return await _context.TodoTasks.FindAsync(id);
        }
            
        public async Task AddTodoTaskAsync(TodoTask todoTask)
        {
            await _context.TodoTasks.AddAsync(todoTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoTaskAsync(int id)
        {
            //TodoTask? todoTask = _todoTasks.SingleOrDefault(x => x.Id == id);
            TodoTask? todoTask = await GetTodoTaskByIdAsync(id);

            if (todoTask != null)
            {
                _context.TodoTasks.Remove(todoTask);
                await _context.SaveChangesAsync();
            }
        }

    }
}
