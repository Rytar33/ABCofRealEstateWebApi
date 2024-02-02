using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Hostels;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class HostelController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid idHostel)
        {
            var hostel = await new HostelService().Get(idHostel);
            if (hostel.IsSuccses == false) return NotFound();
            return Ok(hostel);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] HostelCreateRequest garage)
        {
            var response = await new HostelService().Create(garage);
            return Created($"ABCofRealEstate/Hostel?idHostel={response.Data!.IdHostel}", response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(HostelChangeRequest garage)
        {
            var response = await new HostelService().Change(garage);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idHostel)
        {
            var response = await new HostelService().Delete(idHostel);
            return Ok(response);
        }
    }
}
