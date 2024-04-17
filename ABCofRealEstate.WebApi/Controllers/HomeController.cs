using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers;

[ApiController]
[Route("ABCofRealEstate/[controller]")]
public class HomeController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View("~/Views/ABCofRealEstate/Home/Index.cshtml");
    }
}