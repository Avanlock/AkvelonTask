using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTestTask.Models.DTO;
using AkvelonTestTask.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project = AkvelonTestTask.Models.DbModels.Project;

namespace AkvelonTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("GetAllProjects")]
        public async Task<ActionResult<List<Models.DTO.Project>>> GetAllProjects()
        {
            try
            {
                var projects = await _projectRepository.GetAllProjectsAsync();
                if (projects is null)
                    return NotFound();
                var projectsDTO = _mapper.Map<List<Models.DTO.Project>>(projects);
                return Ok(projectsDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route("GetProjectByIdAsync/{id:guid}")]
        [ActionName("GetProjectByIdAsync")]
        public async Task<ActionResult<List<Models.DTO.Project>>> GetProjectByIdAsync(Guid id)
        {
            try
            {
                var projects = await _projectRepository.GetProjectByIdAsync(id);
                if (projects is null)
                    return NotFound();
                var projectsDTO = _mapper.Map<Models.DTO.Project>(projects);
                return Ok(projectsDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        [Route("AddProjectAsync")]
        public async Task<ActionResult> AddProjectAsync(AddProjectRequest addProjectRequest)
        {
            try
            {
                var project = new Project()
                {
                    Name = addProjectRequest.Name,
                    StartDate = addProjectRequest.StartDate,
                    CompletionDate = addProjectRequest.CompletionDate,
                    Status = addProjectRequest.Status,
                    Priority = addProjectRequest.Priority
                };
                project = await _projectRepository.AddProjectAsync(project);
                var projectDTO = new Models.DTO.Project()
                {
                    Id = project.Id,
                    Name = project.Name,
                    StartDate = project.StartDate,
                    CompletionDate = project.CompletionDate,
                    Status = project.Status,
                    Priority = project.Priority
                };
                return CreatedAtAction(nameof(GetProjectByIdAsync), new { id = projectDTO.Id }, projectDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete]
        [Route("DeleteProjectAsync/{id:guid}")]
        public async Task<ActionResult> DeleteProjectAsync(Guid id)
        {
            try
            {
                var project = await _projectRepository.DeleteProjectAsync(id);
                if (project is null)
                    return NotFound();
                var projectDTO = new Models.DTO.Project()
                {
                    Id = project.Id,
                    Name = project.Name,
                    StartDate = project.StartDate,
                    CompletionDate = project.CompletionDate,
                    Status = project.Status,
                    Priority = project.Priority
                };

                return Ok(projectDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProjectAsync/{id:guid}")]
        public async Task<ActionResult> UpdateProjectAsync([FromRoute]Guid id, [FromBody]UpdateProjectRequest updateProjectRequest)
        {
            try
            {
                var project = new Project()
                {
                    Name = updateProjectRequest.Name,
                    StartDate = updateProjectRequest.StartDate,
                    CompletionDate = updateProjectRequest.CompletionDate,
                    Status = updateProjectRequest.Status,
                    Priority = updateProjectRequest.Priority
                };
                project = await _projectRepository.UpdateProjectAsync(id, project);
                if (project is null)
                    return NotFound();
                var projectDTO = new Models.DTO.Project()
                {
                    Id = project.Id,
                    Name = project.Name,
                    StartDate = project.StartDate,
                    CompletionDate = project.CompletionDate,
                    Status = project.Status,
                    Priority = project.Priority
                };

                return Ok(projectDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}