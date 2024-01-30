using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.CrudServices.Implementation;
using WebAPIShopStudy.Services.CachedServices;
using WebAPIShopStudy.Services.ModelServices.Interfaces;

namespace WebAPIShopStudy.Services.CrudService.Implementation;

public class ProductService : CachedCrudService<ProductModel>, IProductService {

    public ProductService(ShopDbContext dbContext, 
        ICachedService cachedService) 
        : base(dbContext, cachedService) {
    }

}
