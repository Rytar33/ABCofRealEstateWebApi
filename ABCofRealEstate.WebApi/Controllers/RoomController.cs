using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Rooms;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class RoomController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var room = await new RoomService().Get(id);
            if (room.IsSuccess == false) return NotFound();
            return Ok(room);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] RoomCreateRequest room)
        {
            var response = await new RoomService().Create(room);
            return Created($"ABCofRealEstate/Room?id={response.Data!.Id}", response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(RoomChangeRequest room)
        {
            var response = await new RoomService().Change(room);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await new RoomService().Delete(id);
            return Ok(response);
        }
    }
}
