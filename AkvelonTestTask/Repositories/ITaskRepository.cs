using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = AkvelonTestTask.Models.DbModels.Task;

namespace AkvelonTestTask.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task> GetTaskByIdAsync(Guid id);
        List<Task> GetProjectTasksByName(string name);
        Task<Task> AddTaskAsync(Task task);
        Task<Task> DeleteTaskAsync(Guid id);
        Task<Task> UpdateTaskAsync(Guid id, Task task);
    }
}