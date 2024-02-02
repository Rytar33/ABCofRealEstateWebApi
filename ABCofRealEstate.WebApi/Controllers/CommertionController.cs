using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Commertions;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class CommertionController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid idCommertion)
        {
            var commertion = await new CommertionService().Get(idCommertion);
            if (commertion.IsSuccses == false) return NotFound();
            return Ok(commertion);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CommertionCreateRequest commertion)
        {
            var response = await new CommertionService().Create(commertion);
            return Created($"ABCofRealEstate/Commertion?idCommertion={response.Data!.IdCommertion}", response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CommertionChangeRequest commertion)
        {
            var response = await new CommertionService().Change(commertion);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idCommertion)
        {
            var response = await new CommertionService().Delete(idCommertion);
            return Ok(response);
        }
    }
}
