
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
            var projects = _service.ProjectService.GetAllProjects(false);
            return Ok(projects);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetOneProjectById(Guid id)
        {
            var project = _service.ProjectService.GetOneProjectById(id, false);
            return Ok(project);
        }
    }
}
