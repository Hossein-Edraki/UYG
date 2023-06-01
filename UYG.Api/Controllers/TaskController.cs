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
            if (!ModelState.IsValid)
                return BadRequest();

            var response = new AddTaskResponse
            {
                ResponseCode = Common.Response.InProgress,
                ResponseMessage = Common.Response.InProgress.ToString()
            };

            var result = await _taskService.Add(request);
            if (result <= 0)
            {
                response.ResponseCode = Common.Response.Fail;
                response.ResponseMessage = Common.Response.Fail.ToString();
                return BadRequest(response);
            }

            response.ResponseCode = Common.Response.Success;
            response.ResponseMessage = Common.Response.Success.ToString();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _taskService.Get();
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = new AddTaskResponse
            {
                ResponseCode = Common.Response.InProgress,
                ResponseMessage = Common.Response.InProgress.ToString()
            };

            var result = await _taskService.Update(request);
            if (result <= 0)
            {
                response.ResponseCode = Common.Response.Fail;
                response.ResponseMessage = Common.Response.Fail.ToString();
                return BadRequest(response);
            }

            response.ResponseCode = Common.Response.Success;
            response.ResponseMessage = Common.Response.Success.ToString();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute, Required] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = new AddTaskResponse
            {
                ResponseCode = Common.Response.InProgress,
                ResponseMessage = Common.Response.InProgress.ToString()
            };

            var result = await _taskService.Delete(id);
            if (result <= 0)
            {
                response.ResponseCode = Common.Response.Fail;
                response.ResponseMessage = Common.Response.Fail.ToString();
                return BadRequest(response);
            }

            response.ResponseCode = Common.Response.Success;
            response.ResponseMessage = Common.Response.Success.ToString();
            return Ok(response);
        }
    }
}
