using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIShopStudy.Models;
using WebAPIShopStudy.Services.AuthorizationService.Interfaces;
using WebAPIShopStudy.Services.EmailServices.Interfaces;

namespace WebAPIShopStudy.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase {
    public EmailController(IEmailService emailService) {
        _emailService = emailService;
    }


    private readonly IEmailService _emailService;


    [HttpPost]
    [Route("SendEmail")]
    public async Task<IActionResult> SendEmail(MailRequest mailRequest) {
        try {
            await _emailService.SendEmailAsync(mailRequest);
            return new OkResult();
        }
        catch (Exception e) {
            return new BadRequestObjectResult(e.Message);
        }
    }
}
