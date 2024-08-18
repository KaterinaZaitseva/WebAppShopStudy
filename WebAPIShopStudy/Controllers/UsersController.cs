using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.ModelServices.Interfaces;

namespace WebAPIShopStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase {
    
    public UsersController(IUserService userCrudService) {
        _userCrudService = userCrudService;
    }


    private readonly IUserService _userCrudService;


    [Authorize(Roles = "admin, user")]
    [HttpGet]
    public async Task<IActionResult> GetUsers() {
        try {
            return new JsonResult(await _userCrudService.GetAllAsync());
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

    [Authorize(Roles = "admin, user")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id) {
        try {
            return new JsonResult(await _userCrudService.GetByIdAsync(id));
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, UserModel user) {
        try {
            await _userCrudService.UpdateAsync(id, user);
            return new OkResult();
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> PostUser(UserModel user) {
        try {
            await _userCrudService.AddAsync(user);
            return new OkResult();
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id) {
        try {
            await _userCrudService.RemoveAsync(id);
            return new OkResult();
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

}
