using System.ComponentModel.DataAnnotations;
using UYG.Api.Common;

namespace UYG.Api.Models
{
    public class AddTaskRequest
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Priority { get; set; }
        public UYG.Api.Common.TaskStatus Status { get; set; } = Common.TaskStatus.None;
    }
    public class AddTaskResponse
    {
        public Response ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
