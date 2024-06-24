using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Garages;
using Microsoft.AspNetCore.Authorization;
using ABCofRealEstate.Services.Interfaces.Services;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2/[controller]")]
    public class GarageController : Controller
    {
        public GarageController()
        {
            _garageService = new GarageService();
        }

        private readonly IGarageService _garageService;
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _garageService.Get(id);
            return response.IsSuccess
                ? Ok(response.Data)
                : NotFound();
            //View("~/Views/ABCofRealEstate/Garage/Get.cshtml", garage.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] GarageCreateRequest garage)
        {
            var response = await _garageService.Create(garage);
            return response.IsSuccess
                ? Created($"api/v1.2/Garage/{response.Data!.Id}", response.Data)
                : BadRequest(response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(GarageChangeRequest garage)
        {
            var response = await _garageService.Change(garage);
            return response.IsSuccess
                ? NoContent()
                : BadRequest(response);
        }
        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _garageService.Delete(id);
            return response.IsSuccess
                ? NoContent()
                : NotFound();
        }
    }
}
