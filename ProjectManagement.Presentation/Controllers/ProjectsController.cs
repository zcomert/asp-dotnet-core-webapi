
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ProjectManagement.Presentation.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProjectsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                var projects = _service.ProjectService.GetAllProjects(false);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetOneProjectById(Guid id)
        {
            try
            {
                Project project = _service.ProjectService.GetOneProjectById(id, false);
                return Ok(project);
            }
            catch
            {
                return StatusCode(500, "Internal error");
            }

        }
    }
}
