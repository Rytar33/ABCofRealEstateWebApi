using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class PageController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery]SourceRealEstateObjectListRequest sourceRealEstateObject)
        {
            SourceRealEstateObjectService sourceRealEstateObjectService = new SourceRealEstateObjectService();
            return Ok(await sourceRealEstateObjectService.GetList(sourceRealEstateObject));
        }
    }
}
