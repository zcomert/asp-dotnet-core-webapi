using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProjectService(IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProjectDto> GetAllProjects(bool trackChanges)
        {
            try
            {
                var projects = _repository.Project.GetAllProjects(trackChanges);
                var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
                return projectDtos;

            }
            catch (Exception ex)
            {
                _logger.LogError("ProjectService.GetAllProjects() has an error: " + ex.Message);
                throw;
            }

        }

        public ProjectDto GetOneProjectById(Guid id, bool trackChanges)
        {
            try
            {
                var project = _repository.Project.GetOneProjectById(id, trackChanges);
                var projectDto = _mapper.Map<ProjectDto>(project);
                return projectDto;
            }
            catch (Exception ex)
            {
                _logger.LogError("ProjectRepository.GetProject() : " + ex.Message);
                throw;
            }
        }
    }
}