using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Hostels;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class HostelController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var hostel = await new HostelService().Get(id);
            if (hostel.IsSuccess == false) return NotFound();
            return Ok(hostel);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] HostelCreateRequest garage)
        {
            var response = await new HostelService().Create(garage);
            return Created($"ABCofRealEstate/Hostel?id={response.Data!.Id}", response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(HostelChangeRequest garage)
        {
            var response = await new HostelService().Change(garage);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await new HostelService().Delete(id);
            return Ok(response);
        }
    }
}
