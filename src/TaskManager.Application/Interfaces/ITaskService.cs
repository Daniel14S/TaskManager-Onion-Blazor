using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    Task<TaskItem?> GetTaskByIdAsync(int id);
    Task<TaskItem> CreateTaskAsync(TaskItem task);
    Task UpdateTaskAsync(TaskItem task);
    Task DeleteTaskAsync(int id);
    Task CompleteTaskAsync(int id);
    Task<IEnumerable<TaskItem>> GetPendingTasksAsync();
    Task<IEnumerable<TaskItem>> GetCompletedTasksAsync();
}