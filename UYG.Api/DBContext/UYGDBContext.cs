using Microsoft.EntityFrameworkCore;
using UYG.Api.DBContext.Mapping;

namespace UYG.Api.DBContext
{
    public class UYGDBContext : DbContext
    {
        public UYGDBContext()
        {
            
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskMapping());
        }
    }
}
