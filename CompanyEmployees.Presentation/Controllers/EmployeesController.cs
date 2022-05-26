using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController:ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _service.EmployeeService.GetAllEmployees(trackChanges: false);
                return Ok(employees);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server errror");
            }
        }
    }
}
