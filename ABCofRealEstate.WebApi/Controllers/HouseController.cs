using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Houses;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class HouseController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var house = await new HouseService().Get(id);
            if (house.IsSuccess == false) return NotFound();
            return Ok(house);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] HouseCreateRequest house)
        {
            var response = await new HouseService().Create(house);
            return Created($"ABCofRealEstate/House?id={response.Data!.Id}", response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(HouseChangeRequest house)
        {
            var response = await new HouseService().Change(house);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await new HouseService().Delete(id);
            return Ok(response);
        }
    }
}
