using EmployeeAPI.Services.Dtos;
using EmployeeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet("GetEmployeesByDepartment/{department}/{pageNumber}/{pageSize}")]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployeesByDepartment(string department, int pageNumber, int pageSize)
        {
            IEnumerable<EmployeeDto> employees = _employeeService.GetEmployeesByDepartment(department, pageNumber, pageSize);
            if (employees == null || !employees.Any())
            {
                return NotFound();
            }
            return Ok(employees);
        }
    }
}
