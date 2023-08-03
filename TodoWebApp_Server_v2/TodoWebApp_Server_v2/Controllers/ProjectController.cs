﻿using Azure;
using Microsoft.AspNetCore.Mvc;
using TodoWebApp_Server_v2.Dtos.ProjectDto;
using TodoWebApp_Server_v2.Services.ProjectService;

namespace TodoWebApp_Server_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController( IProjectService projectService )
        {
            _projectService = projectService;
        }


        /// <summary>
        /// Get all projects by User_id
        /// </summary>
        [HttpGet("fulldata/{id}")]
        public async Task<IActionResult> GetAllProjectAndSectionByUserId( [FromRoute] Guid id )
        {
            var response = await _projectService.GetAllProjectAndSectionByUserId(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Get all projects by User_id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllProjectByUserId( [FromRoute] Guid id )
        {
            var response = await _projectService.GetAllProjectByUserId(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Get a Project By Name
        /// </summary>
        [HttpGet("projectname/{name}")]
        public async Task<IActionResult> DeleteProjectById( [FromRoute] string name )
        {
            var response = await _projectService.GetProjectByName(name);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Create a Project
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateProject( [FromBody] ProjectCreateRequestDto projectCreateRequestDto )
        {
            var response = await _projectService.CreateProject(projectCreateRequestDto);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }


        /// <summary>
        /// Update a Project By Id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectById( [FromRoute] long id, [FromBody] ProjectUpdateRequestDto projectUpdateRequestDto )
        {
            var response = await _projectService.UpdateProjectById(id, projectUpdateRequestDto);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Force Delete a Project By Id
        /// </summary>
        [HttpDelete("force/{id}")]
        public async Task<IActionResult> ForceDeleteProjectById( [FromRoute] long id )
        {
            var response = await _projectService.ForceDeleteProjectById(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Soft Delete a Project By Id
        /// </summary>
        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDeleteProjectById( [FromRoute] long id )
        {
            var response = await _projectService.SoftDeleteProjectById(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

        /// <summary>
        /// Undo Delete a Project By Id
        /// </summary>
        [HttpPost("undo/{id}")]
        public async Task<IActionResult> UndoDeleteProjectById( [FromRoute] long id )
        {
            var response = await _projectService.UndoDeleteProjectById(id);
            if(response.IsSuccess()) return Ok(response);

            return BadRequest(response);
        }

    }
}
