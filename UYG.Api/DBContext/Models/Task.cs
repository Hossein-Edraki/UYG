namespace UYG.Api.DBContext.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Priority { get; set; }
        public UYG.Api.Common.TaskStatus Status { get; set; }
    }
}
