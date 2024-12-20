using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;
using Todo.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly TodoTaskService _todoTaskService;

        public TodoTaskController(TodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTodoTasks() =>
            Ok(await _todoTaskService.GetAllTodoTasksAsync());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoTask(int id)
        {
            TodoTask? todoTask = await _todoTaskService.GetTodoTaskbyIdAsync(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            return Ok(todoTask);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTodoTask([FromBody] TodoTask todoTask)
        {
            await _todoTaskService.AddTodoTaskAsync(todoTask);
            return CreatedAtAction(nameof(GetTodoTask), new { id = todoTask.Id }, todoTask); 
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoTask(int id)
        {
            await _todoTaskService.DeleteTodoTaskAsync(id);
            return NoContent();
        }
    }
}
