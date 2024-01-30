using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.CrudService.Implementation;
using WebAPIShopStudy.Services.ModelServices.Interfaces;

namespace WebAPIShopStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase {

    public ProductsController(IProductService productCrudService) {
        _productCrudService = productCrudService;
    }


    private readonly IProductService _productCrudService;


    [Authorize(Roles = "admin, user")]
    [HttpGet]
    public async Task<IActionResult> GetProducts() {
        try {
            return Ok(await _productCrudService.GetAllCacheAsync());
        }
        catch (Exception) {
            return NotFound();
        }
    }

    [Authorize(Roles = "admin, user")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id) {
        try {
            return Ok(await _productCrudService.GetByIdCacheAsync(id));
        }
        catch (Exception) {
            return NotFound();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, ProductModel product) {
        try {
            await _productCrudService.UpdateCacheAsync(id, product);
            return Ok();
        }
        catch (Exception) {
            return NotFound();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> PostProduct(ProductModel product) {
        try {
            await _productCrudService.AddCacheAsync(product);
            return Ok();
        }
        catch (Exception) {
            return NotFound();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id) {
        try {
            await _productCrudService.RemoveCacheAsync(id);
            return Ok();
        }
        catch (Exception) {
            return NotFound();
        }
    }

}
