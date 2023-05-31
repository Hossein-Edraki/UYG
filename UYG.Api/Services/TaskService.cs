using UYG.Api.Models;
using UYG.Api.Repository;

namespace UYG.Api.Services
{
    public interface ITaskService
    {
        Task<int> Add(AddTaskRequest request);
        Task<int> Update(UpdateTaskRequest request);
        Task<int> Delete(int id);
        Task<List<UYG.Api.Models.Task>> Get();
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ITaskRepository taskRepository, ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<int> Add(AddTaskRequest request)
        {
            var model = new DBContext.Models.Task
            {
                Date = request.Date,
                Description = request.Description,
                Name = request.Name,
                Priority = request.Priority,
                Status = Common.TaskStatus.None
            };
            var result = await _taskRepository.Add(model);
            if (result <= 0)
            {
                _logger.LogWarning($"Add New Task Failed.model is '{request}'");
            }
            return result;
        }

        public async Task<int> Update(UpdateTaskRequest request)
        {
            var model = new DBContext.Models.Task
            {
                Date = request.Date,
                Description = request.Description,
                Name = request.Name,
                Priority = request.Priority,
                Status = Common.TaskStatus.None,
                Id = request.Id
            };
            var result = await _taskRepository.Update(model);
            if (result <= 0)
            {
                _logger.LogWarning($"Update Task Failed.model is '{request}'");
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var result = await _taskRepository.Delete(id);
            if (result <= 0)
            {
                _logger.LogWarning($"Update Task Failed.id is '{id}'");
            }
            return result;
        }

        public async Task<List<Models.Task>> Get()
        {
            var models = await _taskRepository.Get();
            return models.Select(r => new Models.Task { Date = r.Date, Description = r.Description, Id = r.Id, Name = r.Name, Priority = r.Priority, Status = r.Status }).ToList();
        }
    }
}
