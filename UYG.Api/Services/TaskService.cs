namespace UYG.Api.Services
{
    public interface ITaskService
    {
        Task<int> Add();
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ITaskService taskService, ILogger<TaskService> logger)
        {
            _taskService=taskService;
            _logger=logger;
        }

        public async Task<int> Add()
        {

        }
    }
}
