using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.CrudServices.Implementation;
using WebAPIShopStudy.Services.CachedServices;
using WebAPIShopStudy.Services.ModelServices.Interfaces;

namespace WebAPIShopStudy.Services.CrudService.Implementation;

public class UserService : CachedCrudService<UserModel>, IUserService {

    public UserService(ShopDbContext dbContext,
        ICachedService cachedService)
        : base(dbContext, cachedService) {
    }

}
