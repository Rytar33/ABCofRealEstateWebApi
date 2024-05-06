using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Interfaces;
using ABCofRealEstate.Services.Models.Apartments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers;

[ApiController]
[Route("api/v1.2/[controller]")]
public class ApartmentController : Controller
{
    public ApartmentController()
    {
        _apartmentService = new ApartmentService();
    }

    private readonly IApartmentService _apartmentService;
        
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var response = await _apartmentService.Get(id);
        return response.IsSuccess
            ? Ok(response.Data)
            : NotFound();
        //return View("~/Views/ABCofRealEstate/Apartment/Get.cshtml", response.Data);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] ApartmentCreateRequest apartment)
    {
        var response = await _apartmentService.Create(apartment);
        return response.IsSuccess 
            ? Created($"api/v1.2/Apartment/{response.Data!.Id}", response.Data)
            : BadRequest(response);
    }
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update(ApartmentChangeRequest apartment)
    {
        var response = await _apartmentService.Change(apartment);
        return response.IsSuccess
            ? NoContent()
            : BadRequest(response);
    }
    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var response = await _apartmentService.Delete(id);
        return response.IsSuccess
            ? NoContent()
            : NotFound();
    }
}