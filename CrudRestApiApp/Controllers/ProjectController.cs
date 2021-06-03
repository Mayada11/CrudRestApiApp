using CrudRestApiApp.Models;
using CrudRestApiApp.ProjectData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectData _projectData;
        public ProjectController(IProjectData projectData)
        {
            _projectData = projectData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetProjects()
        {
            return Ok(_projectData.GetProjects());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetProject(int id)
        {
            var project = _projectData.GetProject(id);

            if (project != null)
            {
                return Ok(project);
            }
            return NotFound($"project with id : {id} not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult addProject(Project project)
        {
            _projectData.AddProject(project);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + project.ProjectNo, project.ProjectNo);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _projectData.GetProject(id);

            if (project != null)
            {
                _projectData.DeletProject(project);
                return Ok();
               
            }
            return NotFound($"Project with id : {id} not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditProject(int id, Project project)
        {
            var existingProject = _projectData.GetProject(id);
            if (existingProject != null)
            {
                project.ProjectNo = existingProject.ProjectNo;
                _projectData.EditProject(project);

            }
            return Ok(project);
        }
    }
}
