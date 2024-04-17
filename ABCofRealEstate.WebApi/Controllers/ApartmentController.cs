using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Models.Apartments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class ApartmentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var apartament = await new ApartmentService().Get(id);
            if (apartament.IsSuccess == false) return NotFound();
            return View("~/Views/ABCofRealEstate/Apartment/Get.cshtml", apartament.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]ApartmentCreateRequest apartment)
        {
            var response = await new ApartmentService().Create(apartment);
            return Created($"ABCofRealEstate/Apartment?id={response.Data!.Id}", response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(ApartmentChangeRequest apartment)
        {
            var response = await new ApartmentService().Change(apartment);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var response = await new ApartmentService().Delete(id);
            return Ok(response);
        }
    }
}
