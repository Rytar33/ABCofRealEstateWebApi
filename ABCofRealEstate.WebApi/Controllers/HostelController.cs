using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Hostels;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2/[controller]")]
    public class HostelController : Controller
    {
        public HostelController()
        {
            _hostelService = new HostelService();
        }

        private readonly IHostelService _hostelService;
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _hostelService.Get(id);
            return response.IsSuccess
                ? Ok(response.Data)
                : NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] HostelCreateRequest garage)
        {
            var response = await _hostelService.Create(garage);
            return Created($"api/v1.2/Hostel/{response.Data!.Id}", response.Data);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(HostelChangeRequest garage)
        {
            var response = await _hostelService.Change(garage);
            return response.IsSuccess
                ? NoContent()
                : BadRequest(response);
        }
        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _hostelService.Delete(id);
            return response.IsSuccess
                ? NoContent()
                : NotFound();
        }
    }
}
