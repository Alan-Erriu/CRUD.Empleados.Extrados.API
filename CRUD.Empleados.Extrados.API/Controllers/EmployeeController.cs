using CRUD.Empleados.Extrados.Common.CustomRequest.EmployeeRequest;
using CRUD.Empleados.Extrados.Entities.Models;
using CRUD.Empleados.Extrados.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Empleados.Extrados.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeServices _employeeService;


        public EmployeeController(IEmployeeServices employeeServices1)
        {
            _employeeService = employeeServices1;
        }


        [HttpPost("createemployee")]

        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            await _employeeService.CreateEmployeeService(request);
            return Ok("Succes");
        }



        [HttpPut("disble/{employeeId}")]

        public async Task<IActionResult> UpdateEmployeeStatus(int employeeId)
        {
            await _employeeService.UpdateStatusEmployeeService(employeeId, 0);
            return Ok("Succes");

        }

        [HttpPut("updateemployee")]

        public async Task<IActionResult> UpdateEmployee([FromBody] User employee)
        {
            await _employeeService.UpdateEmployeeService(employee);
            return Ok("Succes");

        }

        [HttpGet("getEmployees/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllEmployee(int pageNumber, int pageSize)
        {
            return Ok(await _employeeService.GetAllEmployeeServices(pageNumber, pageSize));

        }
    }
}
