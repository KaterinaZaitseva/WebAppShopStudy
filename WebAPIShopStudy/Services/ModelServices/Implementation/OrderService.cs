using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.CrudServices.Interfaces;


namespace WebAPIShopStudy.Services.CrudServices.Implementation;

public class OrderService : CrudAsyncService<OrderModel>, IOrderService {

    public OrderService(ShopDbContext dbContext) : base(dbContext) { }

}