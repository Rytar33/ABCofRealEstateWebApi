using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces;
using ABCofRealEstate.Services.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class TeamController : Controller
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            IEmployeeService employeeService = new EmployeeService();
            var employees = await employeeService.Get(id);
            if (employees.IsSuccess == false)
                return NotFound(employees);
            return Ok(employees);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] EmployeeListRequest employeeListRequest)
        {
            IEmployeeService employeeService = new EmployeeService();
            var employees = await employeeService.GetPage(employeeListRequest);
            if(employees.IsSuccess == false)
                return NotFound(employees);
            return View("~/Views/ABCofRealEstate/Team/GetAllEmployees.cshtml", employees.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]EmployeeCreateRequest employeeCreateRequest)
        {
            IEmployeeService employeeService = new EmployeeService();
            var employee = await employeeService.Create(employeeCreateRequest);
            if (employee.IsSuccess == false)
                return BadRequest(employee);
            return Created($"ABCofRealEstate/Team?id={employee.Data!.Id}", employee);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeChangeRequest employeeChangeRequest)
        {
            IEmployeeService employeeService = new EmployeeService();
            var employee = await employeeService.Change(employeeChangeRequest);
            if (employee.IsSuccess == false)
                return BadRequest(employee);
            return Ok(employee);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            IEmployeeService employeeService = new EmployeeService();
            var response = await employeeService.Delete(id);
            if (response.IsSuccess == false)
                return NotFound(response);
            return NoContent();
        }
    }
}
