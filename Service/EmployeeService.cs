using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Employee> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges)
        {
            try
            {
                var employeeList = _repository.Employee.GetEmployeesByProjectId(projectId, trackChanges);
                return employeeList;
            }
            catch (Exception ex)
            {
                _logger.LogError("EmployeeService.GetAllEmployeesByProjectId : " + ex.Message);
                throw;
            }
        }

        public Employee GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChanges)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeByProjectId(projectId, employeeId, trackChanges);
                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError("EmployeeService.GetOneEmployeeByProjectId : " + ex.Message);
                throw;
            }
        }
    }
}