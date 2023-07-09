using Microsoft.AspNetCore.Mvc;
using WebAPIShopStudy.Models;
using WebAPIShopStudy.Services.AuthorizationService.Interfaces;

namespace WebAPIShopStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase {

    public AuthorizationController(IAuthorizationService authorizationService, 
        IRegistrationService registrationService) {
        _authorizationService = authorizationService;
        _registrationService = registrationService;
    }


    private readonly IAuthorizationService _authorizationService;
    private readonly IRegistrationService _registrationService;


    [HttpPost]
    [Route("Authorize")]
    public async Task<IActionResult> LogIn(UserAuthorizationModel model) {
        try {
            return new OkObjectResult(await _authorizationService.AuthorizeAsync(model));
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(UserRegistrationModel model) {
        try {
            await _registrationService.RegisterAsync(model);
            return new OkResult();
        }
        catch(Exception) {
            return new BadRequestResult();
        }
    }
}