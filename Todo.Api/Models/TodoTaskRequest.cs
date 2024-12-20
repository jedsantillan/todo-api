namespace Todo.Api.Models
{
    public class TodoTaskRequest
    {
        public string Name { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
    }
}
