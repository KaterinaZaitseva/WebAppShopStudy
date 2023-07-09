using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.CrudService.Implementation;
using WebAPIShopStudy.Services.CrudService.Interfaces;

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
    public async Task<IEnumerable<ProductModel>?> GetProducts() {
        try {
            return await _productCrudService.GetAllAsync();
        }
        catch (Exception) {
            return null;
        }
    }

    [Authorize(Roles = "admin, user")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id) {
        try {
            return new OkObjectResult(await _productCrudService.GetByIdAsync(id));
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, ProductModel product) {
        try {
            await _productCrudService.UpdateAsync(id, product);
            return new OkResult();
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> PostProduct(ProductModel product) {
        try {
            await _productCrudService.AddAsync(product);
            return new OkResult();
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id) {
        try {
            await _productCrudService.RemoveAsync(id);
            return new OkResult();
        }
        catch (Exception) {
            return new NotFoundResult();
        }
    }

}
