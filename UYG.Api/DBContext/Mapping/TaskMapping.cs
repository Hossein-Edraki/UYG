using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UYG.Api.DBContext.Mapping
{
    public class TaskMapping : IEntityTypeConfiguration<DBContext.Models.Task>
    {
        public void Configure(EntityTypeBuilder<DBContext.Models.Task> builder)
        {
            builder.HasKey(t => t.Id);

            builder
            .Property(b => b.Id)
            .IsRequired();

            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Description);
            builder.Property(b => b.Priority).IsRequired();
            builder.Property(b => b.Date).IsRequired();
            builder.Property(b => b.Status).IsRequired();
        }
    }
}
