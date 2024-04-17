using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Garages;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class GarageController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var garage = await new GarageService().Get(id);
            if (garage.IsSuccess == false) return NotFound();
            return View("~/Views/ABCofRealEstate/Garage/Get.cshtml", garage.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] GarageCreateRequest garage)
        {
            var response = await new GarageService().Create(garage);
            return Created($"ABCofRealEstate/Garage?id={response.Data!.Id}", response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(GarageChangeRequest garage)
        {
            var response = await new GarageService().Change(garage);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await new GarageService().Delete(id);
            return Ok(response);
        }
    }
}
