using Entities.Models;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges);
        Employee GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChanges);
    }
}