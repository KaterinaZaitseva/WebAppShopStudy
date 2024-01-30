using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudService.Interfaces;

namespace WebAPIShopStudy.Services.CrudServices.Interfaces;

public interface IOrderService : ICrudService<OrderModel>, ICrudAsyncService<OrderModel> { }
