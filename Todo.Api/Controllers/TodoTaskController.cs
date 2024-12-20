using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;
using Todo.Application.Services;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IMapper _mapper;

        public TodoTaskController(ITodoTaskService todoTaskService, IMapper mapper)
        {
            _todoTaskService = todoTaskService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTodoTasks() =>
            Ok(await _todoTaskService.GetAllTodoTasksAsync());


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTodoTask([FromBody] TodoTaskRequest todoTaskRequest)
        {
            if (todoTaskRequest == null)
            {
                return BadRequest();
            }

            var todoTask = _mapper.Map<TodoTaskRequest, TodoTask>(todoTaskRequest);

            await _todoTaskService.AddTodoTaskAsync(todoTask);
            return CreatedAtAction(nameof(GetTodoTask), new { id = todoTask.Id }, todoTask); 
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTodoTask(int id)
        {
            TodoTask? todoTask = await _todoTaskService.GetTodoTaskbyIdAsync(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            await _todoTaskService.DeleteTodoTaskAsync(id);
            return NoContent();
        }
    }
}
