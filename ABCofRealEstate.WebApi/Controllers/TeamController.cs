using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Models.Employees;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class TeamController : Controller
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid idEmployee)
        {
            EmployeeService employeeService = new EmployeeService();
            var employees = await employeeService.Get(idEmployee);
            if (employees.IsSuccses == false)
                return NotFound(employees);
            return Ok(employees);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            EmployeeService employeeService = new EmployeeService();
            var employees = await employeeService.GetAllEmployees();
            if(employees.IsSuccses == false)
                return NotFound(employees);
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]EmployeeCreateRequest employeeCreateRequest)
        {
            EmployeeService employeeService = new EmployeeService();
            var employee = await employeeService.Create(employeeCreateRequest);
            if (employee.IsSuccses == false)
                return BadRequest(employee);
            return Created($"ABCofRealEstate/Team?idEmployee={employee.Data!.IdEmployee}", employee);
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeChangeRequest employeeChangeRequest)
        {
            EmployeeService employeeService = new EmployeeService();
            var employee = await employeeService.Change(employeeChangeRequest);
            if (employee.IsSuccses == false)
                return BadRequest(employee);
            return Ok(employee);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idEmployee)
        {
            EmployeeService employeeService = new EmployeeService();
            var response = await employeeService.Delete(idEmployee);
            if (response.IsSuccses == false)
                return NotFound(response);
            return NoContent();
        }
    }
}
