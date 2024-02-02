using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Rooms;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class RoomController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid idRoom)
        {
            var room = await new RoomService().Get(idRoom);
            if (room.IsSuccses == false) return NotFound();
            return Ok(room);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] RoomCreateRequest room)
        {
            var response = await new RoomService().Create(room);
            return Created($"ABCofRealEstate/Room?idRoom={response.Data!.IdRoom}", response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(RoomChangeRequest room)
        {
            var response = await new RoomService().Change(room);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idRoom)
        {
            var response = await new RoomService().Delete(idRoom);
            return Ok(response);
        }
    }
}
