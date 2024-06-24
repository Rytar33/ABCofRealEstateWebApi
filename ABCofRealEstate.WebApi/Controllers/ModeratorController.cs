using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Moderators;
using Microsoft.AspNetCore.Authorization;
using ABCofRealEstate.Services.Interfaces.Services;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2")]
    public class ModeratorController : Controller
    {
        public ModeratorController()
        {
            _moderatorService = new ModeratorService();
        }

        private readonly IModeratorService _moderatorService;
        
        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Login(ModeratorAuthenticationRequest moderatorAuthenticationRequest)
        {
            var responseLogIn = await _moderatorService.LogIn(moderatorAuthenticationRequest);
            return !responseLogIn.IsSuccess
                ? BadRequest(responseLogIn.ErrorMessage)
                : Ok(responseLogIn.Data);
        }
        [Authorize]
        [HttpGet("[controller]/{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _moderatorService.Get(id);
            return response.IsSuccess 
                ? Ok(response.Data)
                : NotFound();
        }
        [Authorize]
        [HttpGet("[controller]s")]
        public async Task<IActionResult> GetModeratorsPage([FromQuery] ModeratorListRequest moderatorListRequest)
        {
            var response = await _moderatorService.GetPage(moderatorListRequest);
            return Ok(response.Data);
        }
        [Authorize("IsSuperModerator")]
        [HttpPost("[controller]")]
        public async Task<IActionResult> Add(ModeratorCreateRequest moderator)
        {
            var response = await _moderatorService.Create(moderator);
            return response.IsSuccess 
                ? Created($"api/v1.2/Moderator/{response.Data!.Id}", response.Data)
                : BadRequest(response);
        }
        [Authorize("IsSuperModerator")]
        [HttpPut("[controller]")]
        public async Task<IActionResult> Update(ModeratorChangeRequest moderator)
        {
            var response = await _moderatorService.Change(moderator);
            return response.IsSuccess
                ? NoContent()
                : BadRequest(response);
        }
        [Authorize("IsSuperModerator")]
        [HttpDelete("[controller]/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _moderatorService.Delete(id);
            return response.IsSuccess 
                ? NoContent()
                : NotFound();
        }
    }
}