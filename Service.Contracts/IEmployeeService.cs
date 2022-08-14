using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges);
        EmployeeDto GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool trackChanges);
        EmployeeDto CreateOneEmployeeByProjectId(Guid projectId, EmployeeDtoForCreation employeeDto, bool trackChanges);
    }
}