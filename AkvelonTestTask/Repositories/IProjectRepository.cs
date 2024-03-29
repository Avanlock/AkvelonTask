﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTestTask.Models.DbModels;

namespace AkvelonTestTask.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> DeleteProjectAsync(Guid id);
        Task<Project> UpdateProjectAsync(Guid id, Project project);
    }
}