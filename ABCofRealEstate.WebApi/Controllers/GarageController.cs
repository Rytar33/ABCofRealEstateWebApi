using ABCofRealEstate.Services.Models.Commertions;
using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Garages;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class GarageController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid idGarage)
        {
            var garage = await new GarageService().Get(idGarage);
            if (garage.IsSuccses == false) return NotFound();
            return Ok(garage);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] GarageCreateRequest garage)
        {
            var response = await new GarageService().Create(garage);
            return Created($"ABCofRealEstate/Garage?idGarage={response.Data!.IdGarage}", response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(GarageChangeRequest garage)
        {
            var response = await new GarageService().Change(garage);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idGarage)
        {
            var response = await new GarageService().Delete(idGarage);
            return Ok(response);
        }
    }
}
