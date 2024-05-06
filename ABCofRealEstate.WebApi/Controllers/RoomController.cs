using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Rooms;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2/[controller]")]
    public class RoomController : Controller
    {
        public RoomController()
        {
            _roomService = new RoomService();
        }

        private readonly IRoomService _roomService;
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _roomService.Get(id);
            return response.IsSuccess
                ? Ok(response.Data)
                : NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] RoomCreateRequest room)
        {
            var response = await _roomService.Create(room);
            return response.IsSuccess 
                ? Created($"api/v1.2/Room/{response.Data!.Id}", response.Data)
                : BadRequest(response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(RoomChangeRequest room)
        {
            var response = await _roomService.Change(room);
            return response.IsSuccess
                ? NoContent()
                : BadRequest(response);
        }
        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _roomService.Delete(id);
            return response.IsSuccess
                ? NoContent()
                : NotFound();
        }
    }
}
