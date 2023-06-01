using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UYG.Api.DBContext;

namespace UYG.Api.Repository
{
    public interface ITaskRepository
    {
        Task<int> Add(DBContext.Models.Task task);
        Task<int> Update(DBContext.Models.Task task);
        Task<int> Delete(int id);
        Task<List<DBContext.Models.Task>> Get();
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly UYGDBContext _dbcontext;

        public TaskRepository(UYGDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Add(DBContext.Models.Task task)
        {
            var parameters = new List<SqlParameter>
            {
                    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = task.Name },
                    new SqlParameter("@Description", SqlDbType.NVarChar) { Value = task.Description },
                    new SqlParameter("@Date", SqlDbType.DateTime) { Value = task.Date },
                    new SqlParameter("@Priority", SqlDbType.Int) { Value = task.Priority },
                    new SqlParameter("@Status", SqlDbType.TinyInt) { Value = task.Status }
            };
            var result = await _dbcontext.Database.ExecuteSqlRawAsync("EXEC usp_Task_Insert @Name,@Description,@Date,@Priority,@Status", parameters);
            return result;
        }

        public async Task<int> Update(DBContext.Models.Task task)
        {
            var parameters = new List<SqlParameter>
            {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = task.Id },
                    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = task.Name },
                    new SqlParameter("@Description", SqlDbType.NVarChar) { Value = task.Description },
                    new SqlParameter("@Date", SqlDbType.DateTime) { Value = task.Date },
                    new SqlParameter("@Priority", SqlDbType.Int) { Value = task.Priority },
                    new SqlParameter("@Status", SqlDbType.TinyInt) { Value = task.Status }
            };
            var result = await _dbcontext.Database.ExecuteSqlRawAsync("EXEC usp_Task_Update @Id,@Name,@Description,@Date,@Priority,@Status", parameters);
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id },
            };
            var result = await _dbcontext.Database.ExecuteSqlRawAsync("EXEC usp_Task_Delete @Id", parameters);
            return result;
        }

        public async Task<List<DBContext.Models.Task>> Get()
        {
            var result = await _dbcontext.Tasks.FromSqlRaw("EXEC usp_Task_Select").ToListAsync();
            return result;
        }
    }
}
