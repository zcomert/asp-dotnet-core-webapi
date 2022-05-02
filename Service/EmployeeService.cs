using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges)
        {
            CheckProjectExists(projectId);

            var employeeList = _repository.Employee
                .GetEmployeesByProjectId(projectId, trackChanges);

            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employeeList);
            return employeeDtos;
        }

        public EmployeeDto GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChanges)
        {
            CheckProjectExists(projectId);

            var employee = _repository.Employee.GetEmployeeByProjectId(projectId, employeeId, trackChanges);

            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        private void CheckProjectExists(Guid projectId)
        {
            var project = _repository.Project.GetOneProjectById(projectId, trackChanges: false);
            if (project is null)
                throw new ProjectNotFoundException(projectId);
        }
    }
}