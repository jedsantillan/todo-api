using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

namespace Todo.Application.Services
{
    public class TodoTaskService
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskService(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public async Task<List<TodoTask>> GetAllTodoTasksAsync() => await _todoTaskRepository.GetAllTodoTasksAsync();
        public async Task<TodoTask?> GetTodoTaskbyIdAsync(int id) => await _todoTaskRepository.GetTodoTaskByIdAsync(id);
        public async Task AddTodoTaskAsync(TodoTask todoTask) => await _todoTaskRepository.AddTodoTaskAsync(todoTask);
        public async Task DeleteTodoTaskAsync(int id) => await _todoTaskRepository.DeleteTodoTaskAsync(id);

    }
}
