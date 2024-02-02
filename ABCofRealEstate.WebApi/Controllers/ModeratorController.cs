using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Moderators;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class ModeratorController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid idModerator)
        {
            var moderator = await new ModeratorService().Get(idModerator);
            if (moderator.IsSuccses == false) return NotFound();
            return Ok(moderator);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ModeratorCreateRequest moderator)
        {
            var response = await new ModeratorService().Create(moderator);
            return Created($"ABCofRealEstate/House?idHouse={response.Data!.IdModerator}", response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ModeratorChangeRequest moderator)
        {
            var response = await new ModeratorService().Change(moderator);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idModerator)
        {
            var response = await new ModeratorService().Delete(idModerator);
            return Ok(response);
        }
    }
}
