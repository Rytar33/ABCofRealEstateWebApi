using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces.Services;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1.2/[controller]")]
    public class CatalogController : Controller
    {
        public CatalogController()
        {
            _sourceRealEstateObjectService = new SourceRealEstateObjectService();
        }

        private readonly ISourceRealEstateObjectService _sourceRealEstateObjectService;
        
        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] SourceRealEstateObjectListRequest sourceRealEstateObject)
        {
            var pageResponse = await _sourceRealEstateObjectService.GetPage(sourceRealEstateObject);
            return Ok(pageResponse.Data);
            //View("~/Views/ABCofRealEstate/Page/GetPage.cshtml", pageResponse.Data);
        }
    }
}
