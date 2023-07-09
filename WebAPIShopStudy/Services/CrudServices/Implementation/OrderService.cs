using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.CrudService.Implementation;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Services.CrudServices.Implementation;

public class OrderService : CrudService<OrderModel>, IOrderService {

    public OrderService(ShopDbContext dbContext) : base(dbContext) { }

}