using AutoMapper;
using Contracts;
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
            try
            {
                var employeeList = _repository.Employee
                    .GetEmployeesByProjectId(projectId, trackChanges);

                var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employeeList);
                return employeeDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError("EmployeeService.GetAllEmployeesByProjectId : " + ex.Message);
                throw;
            }
        }

        public EmployeeDto GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChanges)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeByProjectId(projectId, employeeId, trackChanges);
                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return employeeDto;
            }
            catch (Exception ex)
            {
                _logger.LogError("EmployeeService.GetOneEmployeeByProjectId : " + ex.Message);
                throw;
            }
        }
    }
}