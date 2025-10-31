namespace SmartTasks.DTOs
{
    public class CreateTaskItemDto
    {
        public string Title { get; set; } = string.Empty;
        public int ProjectId { get; set; }
    }
}
