using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Moderators;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class ModeratorController : Controller
    {
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login(ModeratorAuthenticationRequest moderatorAuthenticationRequest)
        {
            var responseLogIn = await new ModeratorService().LogIn(moderatorAuthenticationRequest);
            return !responseLogIn.IsSuccess 
                ? Unauthorized(responseLogIn)
                : Ok(responseLogIn);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var moderator = await new ModeratorService().Get(id);
            if (moderator.IsSuccess == false) return NotFound();
            return Ok(moderator);
        }
        [Authorize(Roles = "SuperModerator")]
        [HttpPost]
        public async Task<IActionResult> Add(ModeratorCreateRequest moderator)
        {
            var response = await new ModeratorService().Create(moderator);
            return Created($"ABCofRealEstate/Moderator?id={response.Data!.Id}", response);
        }
        [Authorize(Roles = "SuperModerator")]
        [HttpPut]
        public async Task<IActionResult> Update(ModeratorChangeRequest moderator)
        {
            var response = await new ModeratorService().Change(moderator);
            return Ok(response);
        }
        [Authorize(Roles = "SuperModerator")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await new ModeratorService().Delete(id);
            return Ok(response);
        }
    }
}
