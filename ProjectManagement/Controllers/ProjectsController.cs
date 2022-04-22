using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private List<Project> _projectList;
        public ProjectsController()
        {
            _projectList = new List<Project>
            {
                new Project { Id = Guid.NewGuid(), Name ="Project 1"},
                new Project { Id = Guid.NewGuid(), Name ="Project 2"},
                new Project { Id = Guid.NewGuid(), Name ="Project 3"}
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_projectList);
        }
    }
}
