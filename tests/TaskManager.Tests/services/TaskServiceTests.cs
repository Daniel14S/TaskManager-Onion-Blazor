using Moq;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Domain.Entities;

namespace TaskManager.Tests.Services;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _mockRepository;
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        _mockRepository = new Mock<ITaskRepository>();
        _taskService = new TaskService(_mockRepository.Object);
    }

    [Fact]
    public async Task CreateTaskAsync_ShouldSetCreatedAtAndIsCompleted()
    {
        // Arrange
        var task = new TaskItem
        {
            Title = "Test Task",
            Description = "Test Description",
            Priority = TaskPriority.Medium
        };

        _mockRepository
            .Setup(r => r.CreateTaskAsync(It.IsAny<TaskItem>()))
            .ReturnsAsync(task);

        // Act
        var result = await _taskService.CreateTaskAsync(task);

        // Assert
        Assert.False(result.IsCompleted);
        Assert.NotEqual(default(DateTime), result.CreatedAt);
        _mockRepository.Verify(r => r.CreateTaskAsync(It.IsAny<TaskItem>()), Times.Once);
    }

    [Fact]
    public async Task CompleteTaskAsync_ShouldMarkTaskAsCompleted()
    {
        // Arrange
        var taskId = 1;
        var task = new TaskItem
        {
            Id = taskId,
            Title = "Test Task",
            IsCompleted = false
        };

        _mockRepository
            .Setup(r => r.GetTaskByIdAsync(taskId))
            .ReturnsAsync(task);

        // Act
        await _taskService.CompleteTaskAsync(taskId);

        // Assert
        Assert.True(task.IsCompleted);
        Assert.NotNull(task.CompletedAt);
        _mockRepository.Verify(r => r.UpdateTaskAsync(task), Times.Once);
    }

    [Fact]
    public async Task GetPendingTasksAsync_ShouldCallRepositoryWithFalse()
    {
        // Arrange
        var pendingTasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Task 1", IsCompleted = false },
            new TaskItem { Id = 2, Title = "Task 2", IsCompleted = false }
        };

        _mockRepository
            .Setup(r => r.GetTasksByStatusAsync(false))
            .ReturnsAsync(pendingTasks);

        // Act
        var result = await _taskService.GetPendingTasksAsync();

        // Assert
        Assert.Equal(2, result.Count());
        _mockRepository.Verify(r => r.GetTasksByStatusAsync(false), Times.Once);
    }

    [Fact]
    public async Task GetCompletedTasksAsync_ShouldCallRepositoryWithTrue()
    {
        // Arrange
        var completedTasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Task 1", IsCompleted = true }
        };

        _mockRepository
            .Setup(r => r.GetTasksByStatusAsync(true))
            .ReturnsAsync(completedTasks);

        // Act
        var result = await _taskService.GetCompletedTasksAsync();

        // Assert
        Assert.Single(result);
        _mockRepository.Verify(r => r.GetTasksByStatusAsync(true), Times.Once);
    }

    [Fact]
    public async Task DeleteTaskAsync_ShouldCallRepositoryDelete()
    {
        // Arrange
        var taskId = 1;

        // Act
        await _taskService.DeleteTaskAsync(taskId);

        // Assert
        _mockRepository.Verify(r => r.DeleteTaskAsync(taskId), Times.Once);
    }
}