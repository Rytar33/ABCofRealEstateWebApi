using ABCofRealEstate.Services;
using ABCofRealEstate.Services.Models.Sends;
using Microsoft.AspNetCore.Mvc;

namespace ABCofRealEstate.WebApi.Controllers;

[ApiController]
[Route("api/v1.2/[controller]")]
public class SenderController : Controller
{
    [HttpPost("Email/Contact")]
    public async Task<IActionResult> SendEmailMessage(SendEmailContactRequest sendEmailContactRequest)
    {
        var response = await new SendService().SendEmail(sendEmailContactRequest);
        return response.IsSuccess ? NoContent() : BadRequest();
    }

    [HttpPost("Email/ContactUs")]
    public async Task<IActionResult> SendEmailContactMessage(SendEmailContactUsRequest sendEmailContactUsRequest)
    {
        var response = await new SendService().SendEmail(sendEmailContactUsRequest);
        return response.IsSuccess ? NoContent() : BadRequest();
    }
}
