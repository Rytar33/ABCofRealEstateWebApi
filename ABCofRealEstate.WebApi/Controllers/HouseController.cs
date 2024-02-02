using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Houses;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class HouseController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid idHouse)
        {
            var house = await new HouseService().Get(idHouse);
            if (house.IsSuccses == false) return NotFound();
            return Ok(house);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] HouseCreateRequest house)
        {
            var response = await new HouseService().Create(house);
            return Created($"ABCofRealEstate/House?idHouse={response.Data!.IdHouse}", response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(HouseChangeRequest house)
        {
            var response = await new HouseService().Change(house);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idHouse)
        {
            var response = await new HouseService().Delete(idHouse);
            return Ok(response);
        }
    }
}
