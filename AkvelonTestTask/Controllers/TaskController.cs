using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTestTask.Models.DTO;
using AkvelonTestTask.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AkvelonTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("GetAllTasks")]
        public async Task<ActionResult<List<Models.DTO.Task>>> GetAllTasks()
        {
            try
            {
                var tasks = await _taskRepository.GetAllTasksAsync();
                if (tasks is null)
                    return NotFound();
                var tasksDTO = _mapper.Map<List<Models.DTO.Task>>(tasks);
                return Ok(tasksDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route("GetTaskByIdAsync/{id:guid}")]
        [ActionName("GetTaskByIdAsync")]
        public async Task<ActionResult<List<Models.DTO.Task>>> GetTaskByIdAsync(Guid id)
        {
            try
            {
                var task = await _taskRepository.GetTaskByIdAsync(id);
                if (task is null)
                    return NotFound();
                var taskDTO = _mapper.Map<Models.DTO.Task>(task);
                return Ok(taskDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        [Route("AddTaskAsync")]
        public async Task<ActionResult> AddTaskAsync(AddTaskRequest addTaskRequest)
        {
            try
            {
                var task = new Models.DbModels.Task()
                {
                    Name = addTaskRequest.Name,
                    Description = addTaskRequest.Description,
                    Status = addTaskRequest.Status,
                    ProjectId = addTaskRequest.ProjectId
                };
                task = await _taskRepository.AddTaskAsync(task);
                var taskDTO = new Models.DTO.Task()
                {
                    Id = task.Id,
                    Name = addTaskRequest.Name,
                    Description = addTaskRequest.Description,
                    Status = addTaskRequest.Status,
                    ProjectId = addTaskRequest.ProjectId
                };
                return CreatedAtAction(nameof(GetTaskByIdAsync), new { id = taskDTO.Id }, taskDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete]
        [Route("DeleteTaskAsync/{id:guid}")]
        public async Task<ActionResult> DeleteTaskAsync(Guid id)
        {
            try
            {
                var task = await _taskRepository.DeleteTaskAsync(id);
                if (task is null)
                    return NotFound();
                var taskDTO = new Models.DTO.Task()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Status = task.Status,
                    ProjectId = task.ProjectId
                };
                return Ok(taskDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut]
        [Route("UpdateTaskAsync/{id:guid}")]
        public async Task<ActionResult> UpdateTaskAsync([FromRoute]Guid id, [FromBody]UpdateTaskRequest updateProjectRequest)
        {
            try
            {
                var task = new Models.DbModels.Task()
                {
                    Name = updateProjectRequest.Name,
                    Description = updateProjectRequest.Description,
                    Status = updateProjectRequest.Status,
                };
                task = await _taskRepository.UpdateTaskAsync(id, task);
                if (task is null)
                    return NotFound();
                var taskDTO = new Models.DTO.Task()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Status = task.Status,
                    ProjectId = task.ProjectId
                };
                return Ok(taskDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route("GetProjectTasksByName/{name}")]
        public ActionResult<List<Models.DTO.Task>> GetProjectTasksByName(string name)
        {
            try
            {
                var tasks = _taskRepository.GetProjectTasksByName(name);
                if (tasks is null)
                    return NotFound($"{name} project has no tasks");
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}