using AkvelonTestTask.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTestTask.Models.Context
{
    public class ProjectTasksDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ProjectTasksDbContext(DbContextOptions<ProjectTasksDbContext> options) : base(options)
        {
            
        }
    }
}