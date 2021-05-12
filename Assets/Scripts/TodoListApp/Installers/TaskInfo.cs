using TodoListApp.Models.Interfaces;

namespace TodoListApp.Installers
{
    public class TaskInfo : ITaskInfo
    {
        public int Id { get; set; }
        public string Title { get; }
        public string Description { get; }

        public TaskInfo(string title, string description)
        {
            Title = title;
            Description = description;
        }
        
        public bool IsValidTask()
        {
            return Title != "";
        }
    }
}