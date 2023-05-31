namespace UYG.Api.Repository
{
    public interface ITaskRepository
    {
        Task<int> Add();
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly DBContext.UYGDBContext _dbcontext;

        public TaskRepository(DBContext.UYGDBContext dbcontext)
        {
            _dbcontext=dbcontext;
        }

        public async Task<int> Add()
        {

        }
    }
}
