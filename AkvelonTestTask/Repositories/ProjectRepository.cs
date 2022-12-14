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

        public async Task<IEnumerable<Project>> GetAllProjectsAsync() => await _context.Projects.ToListAsync();

        public async Task<Project> GetProjectByIdAsync(Guid id) =>
            await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
    }
}