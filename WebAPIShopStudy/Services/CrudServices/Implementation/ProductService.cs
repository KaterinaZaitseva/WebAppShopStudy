using Microsoft.EntityFrameworkCore;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.CrudService.Interfaces;

namespace WebAPIShopStudy.Services.CrudService.Implementation;

public class ProductService : CrudService<ProductModel>, IProductService {

    public ProductService(ShopDbContext dbContext) : base(dbContext) { }
}
