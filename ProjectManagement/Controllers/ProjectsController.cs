using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ProjectManagement.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private List<Project> _projectList;
        private ILoggerManager _logger;
        private IRepositoryManager _repository;

        public ProjectsController(ILoggerManager logger, IRepositoryManager repository)
        {
            _logger = logger; // DI
            _repository = repository;
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
            try
            {
                _logger.LogInfo("Projects.Get() has been run.");
                var list = _repository.Project.GetAllProjects(false);
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError("Projects.Get() has been crashed : " + ex.Message);
                throw;
            }

        }
    }
}
