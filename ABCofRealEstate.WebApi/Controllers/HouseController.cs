using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ABCofRealEstate.Services.Models.Houses;
using Microsoft.AspNetCore.Authorization;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2/[controller]")]
    public class HouseController : Controller
    {
        public HouseController()
        {
            _houseService = new HouseService();
        }

        private readonly IHouseService _houseService;
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _houseService.Get(id);
            return response.IsSuccess
                ? Ok(response.Data)
                : NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] HouseCreateRequest house)
        {
            var response = await _houseService.Create(house);
            return response.IsSuccess
                ? Created($"api/v1.2/House/{response.Data!.Id}", response.Data)
                : BadRequest(response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(HouseChangeRequest house)
        {
            var response = await _houseService.Change(house);
            return response.IsSuccess
                ? NoContent()
                : BadRequest(response);
        }
        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _houseService.Delete(id);
            return response.IsSuccess 
                ? NoContent()
                : NotFound();
        }
    }
}
