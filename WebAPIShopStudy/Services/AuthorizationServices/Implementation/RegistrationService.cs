using System.Diagnostics.Eventing.Reader;
using WebAPIShopStudy.Models;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Persistence.JWT.Interfaces;
using WebAPIShopStudy.Services.AuthorizationService.Interfaces;
using WebAPIShopStudy.Services.ModelServices.Interfaces;

namespace WebAPIShopStudy.Services.AuthorizationService.Implementation;

public class RegistrationService : IRegistrationService {

    public RegistrationService(IUserService userCrudService) {
        _userCrudService = userCrudService;
    }


    private readonly IUserService _userCrudService;


    public async Task RegisterAsync(UserRegistrationModel model) {
        UserModel? user = await _userCrudService.FirstOrDefaultAsync(
            u => u.Login == model.Login &&
            u.Password == model.Password
        );

        if (user is not null)
            throw new Exception("User alredy exsist");

        user = new UserModel { Login = model.Login, Password = model.Password };
        await _userCrudService.AddAsync(user);
    }
}
