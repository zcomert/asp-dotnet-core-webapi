using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Presentation.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllEmployeeByProjectId(Guid projectId)
        {
            var employeeList = _service
                .EmployeeService
                .GetAllEmployeesByProjectId(projectId, false);

            return Ok(employeeList);
        }

        [HttpGet("{id:guid}", Name ="GetOneEmployeeByProjectIdAndId")]
        public IActionResult GetOneEmployeeByProjectId(Guid projectId, Guid id)
        {
            var employee = _service
                .EmployeeService
                .GetOneEmployeeByProjectId(projectId, id, false);

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateOneEmployeeByProjectId(Guid projectId, 
            [FromBody] EmployeeDtoForCreation employeeDto)
        {
            EmployeeDto employee = _service
                .EmployeeService
                .CreateOneEmployeeByProjectId(projectId, employeeDto, true);

            return CreatedAtRoute("GetOneEmployeeByProjectIdAndId", 
                new { projectId, id = employee.Id }, 
                employee);
        }

    }
}
