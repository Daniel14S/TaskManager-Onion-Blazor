using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
    {
        return await _repository.GetAllTasksAsync();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int id)
    {
        return await _repository.GetTaskByIdAsync(id);
    }

    public async Task<TaskItem> CreateTaskAsync(TaskItem task)
    {
        task.CreatedAt = DateTime.UtcNow;
        task.IsCompleted = false;
        return await _repository.CreateTaskAsync(task);
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        await _repository.UpdateTaskAsync(task);
    }

    public async Task DeleteTaskAsync(int id)
    {
        await _repository.DeleteTaskAsync(id);
    }

    public async Task CompleteTaskAsync(int id)
    {
        var task = await _repository.GetTaskByIdAsync(id);
        if (task != null)
        {
            task.IsCompleted = true;
            task.CompletedAt = DateTime.UtcNow;
            await _repository.UpdateTaskAsync(task);
        }
    }

    public async Task<IEnumerable<TaskItem>> GetPendingTasksAsync()
    {
        return await _repository.GetTasksByStatusAsync(false);
    }

    public async Task<IEnumerable<TaskItem>> GetCompletedTasksAsync()
    {
        return await _repository.GetTasksByStatusAsync(true);
    }
}