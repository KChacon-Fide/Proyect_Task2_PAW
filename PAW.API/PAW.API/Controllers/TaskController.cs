using Microsoft.AspNetCore.Mvc;
using PAW.Models;
using PAW.Repositories;
using System.Collections.Generic;

namespace PAW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PAW.Models.Task>>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PAW.Models.Task>> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<PAW.Models.Task>> CreateTaskAsync(PAW.Models.Task task)
        {
            await _taskRepository.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetTaskByIdAsync), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, PAW.Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _taskRepository.UpdateTaskAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}
