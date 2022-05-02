using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ProjectService(IRepositoryManager repository,
            ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Project> GetAllProjects(bool trackChanges)
        {
            try
            {
                var projects = _repository.Project.GetAllProjects(trackChanges);
                return projects;
            }
            catch (Exception ex)
            {
                _logger.LogError("ProjectService.GetAllProjects() has an error: " + ex.Message);
                throw;
            }

        }
    }
}