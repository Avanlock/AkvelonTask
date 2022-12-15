using System;
using System.Collections.Generic;
using System.Linq;
using AkvelonTestTask.Models.Context;
using AkvelonTestTask.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTestTask.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ProjectTasksDbContext _context;

        public TaskRepository(ProjectTasksDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            if (tasks.Count == 0)
                return null;
            return tasks;
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByIdAsync(Guid id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task is null)
                return null;
            return task;
        }

        public List<Task> GetProjectTasksByName(string name)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Name == name);
            if (project is null)
                return null;
            var tasks = _context.Tasks.Where(t => t.ProjectId == project.Id).ToList();
            if (tasks.Count == 0)
                return null;
            return tasks;
        }

        public async System.Threading.Tasks.Task<Task> AddTaskAsync(Task task)
        {
            task.Id = Guid.NewGuid();
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async System.Threading.Tasks.Task<Task> DeleteTaskAsync(Guid id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task is null)
                return null;
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async System.Threading.Tasks.Task<Task> UpdateTaskAsync(Guid id, Task task)
        {
            var exisingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (exisingTask is null)
                return null;
            exisingTask.Name = task.Name;
            exisingTask.Description = task.Description;
            exisingTask.Status = task.Status;
            await _context.SaveChangesAsync();
            return exisingTask;
        }
    }
}