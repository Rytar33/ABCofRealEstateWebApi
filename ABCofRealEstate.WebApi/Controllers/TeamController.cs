using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces;
using ABCofRealEstate.Services.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2")]
    public class TeamController : Controller
    {
        public TeamController()
        {
            _employeeService = new EmployeeService();
        }

        private readonly IEmployeeService _employeeService; 
        
        [HttpGet("[controller]/{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _employeeService.Get(id);
            return response.IsSuccess
                ? Ok(response.Data)
                : NotFound();
        }
        [HttpGet("[controller]s/Short")]
        public async Task<IActionResult> GetShortListEmployees()
        {
            var response = await new EmployeeService().GetShortList();
            return Ok(response.Data);
        }
        [HttpGet("[controller]s")]
        public async Task<IActionResult> GetAllEmployees([FromQuery] EmployeeListRequest employeeListRequest)
        {
            var response = await _employeeService.GetPage(employeeListRequest);
            return Ok(response.Data);
            //return View("~/Views/ABCofRealEstate/Team/GetAllEmployees.cshtml", employees.Data);
        }
        [Authorize]
        [HttpPost("[controller]")]
        public async Task<IActionResult> Add([FromForm]EmployeeCreateRequest employeeCreateRequest)
        {
            var response = await _employeeService.Create(employeeCreateRequest);
            return response.IsSuccess
                ? Created($"api/v1.2/Team/{response.Data!.Id}", response.Data)
                : BadRequest(response);
        }
        [Authorize]
        [HttpPut("[controller]")]
        public async Task<IActionResult> Update(EmployeeChangeRequest employeeChangeRequest)
        {
            var response = await _employeeService.Change(employeeChangeRequest);
            return response.IsSuccess
                ? NoContent()
                : BadRequest(response);
        }
        [Authorize]
        [HttpDelete("[controller]/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _employeeService.Delete(id);
            return response.IsSuccess
                ? NoContent()
                : NotFound();
        }
    }
}
