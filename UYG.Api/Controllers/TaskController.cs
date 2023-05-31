using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UYG.Api.Models;
using UYG.Api.Services;

namespace UYG.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTaskRequest request)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var response = await _taskService.Add(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _taskService.Get();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var response = await _taskService.Update(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute, Required] int id)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var response = await _taskService.Delete(id);
            return Ok();
        }
    }
}
