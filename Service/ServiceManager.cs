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
        private readonly Lazy<IProjectService> _projectService;
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _projectService =
                new Lazy<IProjectService>(() => new ProjectService(repository, logger));

            _employeeService =
                new Lazy<IEmployeeService>(() => new EmployeeService(repository, logger));

        }

        public IProjectService ProjectService => _projectService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
