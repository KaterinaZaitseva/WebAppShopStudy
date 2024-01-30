using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIShopStudy.Models;
using WebAPIShopStudy.Services.EmailServices.Interfaces;

namespace WebAPIShopStudy.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HostController : ControllerBase {

    public HostController(IHostedService hostedService) {
        _hostedService = hostedService;
        _cancellationToken = new CancellationToken();
    }


    private readonly IHostedService _hostedService;
    private readonly CancellationToken _cancellationToken;

    [HttpGet]
    [Route("startTask")]
    public IActionResult Start() {
        try {
            _hostedService.StartAsync(new CancellationToken());
            return new OkResult();
        }
        catch (Exception) {
            return new BadRequestResult();
        }
    }

    [HttpGet]
    [Route("stopTask")]
    public IActionResult Stop() {
        try {
            _hostedService.StopAsync(new CancellationToken());
            return new OkResult();
        }
        catch (Exception) {
            return new BadRequestResult();
        }
    }
}
