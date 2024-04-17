using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Areas;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class AreaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var area = await new AreaService().Get(id);
            if (area.IsSuccess == false) return NotFound();
            return View("~/Views/ABCofRealEstate/Area/Get.cshtml", area.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AreaCreateRequest area)
        {
            var response = await new AreaService().Create(area);
            return Created($"ABCofRealEstate/Area?id={response.Data!.Id}", response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(AreaChangeRequest area)
        {
            var response = await new AreaService().Change(area);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await new AreaService().Delete(id);
            return Ok(response);
        }
    }
}
