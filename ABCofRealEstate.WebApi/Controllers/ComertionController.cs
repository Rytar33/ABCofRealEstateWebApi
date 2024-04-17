using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Comertions;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class ComertionController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var comertion = await new ComertionService().Get(id);
            if (comertion.IsSuccess == false) return NotFound();
            return View("~/Views/ABCofRealEstate/Comertion/Get.cshtml", comertion.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ComertionCreateRequest comertion)
        {
            var response = await new ComertionService().Create(comertion);
            return Created($"ABCofRealEstate/Comertion?id={response.Data!.Id}", response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(ComertionChangeRequest comertion)
        {
            var response = await new ComertionService().Change(comertion);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await new ComertionService().Delete(id);
            return Ok(response);
        }
    }
}
