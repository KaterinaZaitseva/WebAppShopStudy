using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Services.CrudService.Interfaces;

namespace WebAPIShopStudy.Services.CrudService.Implementation;

public class UserService : CrudService<UserModel>, IUserService {

    public UserService(ShopDbContext dbContext) : base(dbContext) { }

   
}
