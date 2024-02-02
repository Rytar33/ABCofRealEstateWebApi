using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Models.Apartaments;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class ApartamentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid idApartament)
        {
            var apartament = await new ApartamentService().Get(idApartament);
            if (apartament.IsSuccses == false) return NotFound();
            return Ok(apartament);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]ApartamentCreateRequest apartament)
        {
            var response = await new ApartamentService().Create(apartament);
            return Created($"ABCofRealEstate/Apartament?idApartament={response.Data!.IdApartament}", response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ApartamentChangeRequest apartament)
        {
            var response = await new ApartamentService().Change(apartament);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idApartament)
        {
            var response = await new ApartamentService().Delete(idApartament);
            return Ok(response);
        }
    }
}
