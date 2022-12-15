using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkvelonTestTask.Models.Context;
using AkvelonTestTask.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTestTask.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectTasksDbContext _context;

        public ProjectRepository(ProjectTasksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            if (projects.Count == 0)
                return null;
            return projects;
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project is null)
                return null;
            return project;
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            project.Id = Guid.NewGuid();
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteProjectAsync(Guid id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project is null)
                return null;
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProjectAsync(Guid id, Project project)
        {
            var exisingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (exisingProject is null)
                return null;
            exisingProject.Name = project.Name;
            exisingProject.Priority = project.Priority;
            exisingProject.Status = project.Status;
            exisingProject.CompletionDate = project.CompletionDate;
            exisingProject.StartDate = project.StartDate;
            await _context.SaveChangesAsync();
            return exisingProject;
        }
    }
}