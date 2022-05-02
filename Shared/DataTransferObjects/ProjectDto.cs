using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProjectDto(Guid Id, string Name, string Description, string Field);
    public record EmployeeDto(Guid Id, string FirstName, string LastName, int Age, string Position);
    
}
