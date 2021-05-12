namespace TodoListApp.Models.Interfaces
{
    public interface ITaskInfo : IEntity
    {
        string Title { get; }
        string Description { get; }
        bool IsValidTask();
    }
}