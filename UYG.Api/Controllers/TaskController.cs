using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UYG.Api.Models;

namespace UYG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public TaskController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTaskRequest request)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute, Required] int id)
        {
            return Ok();
        }
    }
}
