using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Comertions;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2/[controller]")]
    public class ComertionController : Controller
    {
        public ComertionController()
        {
            _comertionService = new ComertionService();
        }

        private readonly IComertionService _comertionService;
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _comertionService.Get(id);
            return response.IsSuccess
                ? Ok(response.Data)
                : NotFound();
            //View("~/Views/ABCofRealEstate/Comertion/Get.cshtml", comertion.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ComertionCreateRequest comertion)
        {
            var response = await _comertionService.Create(comertion);
            return response.IsSuccess 
                ? Created($"api/v1.2/Comertion/{response.Data!.Id}", response.Data)
                : BadRequest(response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(ComertionChangeRequest comertion)
        {
            var response = await _comertionService.Change(comertion);
            return response.IsSuccess
                ? NoContent()
                : BadRequest(response);
        }
        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _comertionService.Delete(id);
            return response.IsSuccess
                ? NoContent()
                : NotFound();
        }
    }
}
