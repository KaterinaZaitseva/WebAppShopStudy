using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Services.CrudService.Interfaces;

public interface IProductService : ICrudService<ProductModel>, ICrudAsyncService<ProductModel> {
}