using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTestTask.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<List<Models.DTO.Project>>> GetAllProjects()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            var projectsDTO = _mapper.Map<List<Models.DTO.Project>>(projects);
            return Ok(projectsDTO);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Models.DTO.Project>>> GetProjectById(Guid id)
        {
            var projects = await _projectRepository.GetProjectByIdAsync(id);
            var projectsDTO = _mapper.Map<List<Models.DTO.Project>>(projects);
            return Ok(projectsDTO);
        }
    }
}