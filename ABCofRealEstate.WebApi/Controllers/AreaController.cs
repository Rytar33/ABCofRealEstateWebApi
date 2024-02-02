using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Areas;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class AreaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid idArea)
        {
            var area = await new AreaService().Get(idArea);
            if (area.IsSuccses == false) return NotFound();
            return Ok(area);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AreaCreateRequest area)
        {
            var response = await new AreaService().Create(area);
            return Created($"ABCofRealEstate/Area?idArea={response.Data!.IdArea}", response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(AreaChangeRequest area)
        {
            var response = await new AreaService().Change(area);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idArea)
        {
            var response = await new AreaService().Delete(idArea);
            return Ok(response);
        }
    }
}
