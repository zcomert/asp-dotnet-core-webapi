using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProjectService _projectService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _projectService = new ProjectService(repository, logger);
        }

        public IProjectService ProjectService => _projectService;
    }
}
