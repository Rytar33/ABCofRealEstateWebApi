using ABCofRealEstate.Services;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Areas;
using Microsoft.AspNetCore.Authorization;
using ABCofRealEstate.Services.Interfaces.Services;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2/[controller]")]
    public class AreaController : Controller
    {
        public AreaController()
        {
            _areaService = new AreaService();
        }

        private readonly IAreaService _areaService;
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _areaService.Get(id);
            return response.IsSuccess
                ? Ok(response.Data)
                : NotFound();
            //View("~/Views/ABCofRealEstate/Area/Get.cshtml", area.Data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AreaCreateRequest area)
        {
            var response = await _areaService.Create(area);
            return response.IsSuccess 
                ? Created($"api/v1.2/Area/{response.Data!.Id}", response.Data)
                : BadRequest(response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(AreaChangeRequest area)
        {
            var response = await _areaService.Change(area);
            return response.IsSuccess
                ? NoContent()
                : BadRequest(response);
        }
        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _areaService.Delete(id);
            return response.IsSuccess
                ? NoContent()
                : NotFound();
        }
    }
}
