using Entities.Models;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployeesByProjectId(Guid projectId, bool trackChanges);
        Employee GetEmployeeByProjectId(Guid projectId, Guid id, bool trackChanges);

        void CreateEmployeeForProject(Guid projectId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
