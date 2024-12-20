﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Interfaces
{
    public interface ITodoTaskService
    {
        Task<List<TodoTask>> GetAllTodoTasksAsync();
        Task<TodoTask?> GetTodoTaskbyIdAsync(int id);
        Task AddTodoTaskAsync(TodoTask todoTask);
        Task DeleteTodoTaskAsync(int id);
    }
}
