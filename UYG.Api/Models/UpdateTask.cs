using System.ComponentModel.DataAnnotations;

namespace UYG.Api.Models
{
    public class UpdateTaskRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Priority { get; set; }
        public UYG.Api.Common.TaskStatus Status { get; set; }
    }
    public class UpdateTaskResponse
    {
    }
}
