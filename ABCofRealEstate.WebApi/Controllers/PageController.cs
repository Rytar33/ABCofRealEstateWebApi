using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers
{
    [ApiController]
    [Route("ABCofRealEstate/[controller]")]
    public class PageController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] SourceRealEstateObjectListRequest sourceRealEstateObject)
        {
            ISourceRealEstateObjectService sourceRealEstateObjectService = new SourceRealEstateObjectService();
            var pageResponse = await sourceRealEstateObjectService.GetPage(sourceRealEstateObject);
            return View("~/Views/ABCofRealEstate/Page/GetPage.cshtml", pageResponse.Data);
        }
    }
}
