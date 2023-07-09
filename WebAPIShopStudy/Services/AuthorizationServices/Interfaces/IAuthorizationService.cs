using WebAPIShopStudy.Models;

namespace WebAPIShopStudy.Services.AuthorizationService.Interfaces;

public interface IAuthorizationService {

    public Task<UserResponseAuthorizationModel> AuthorizeAsync(UserAuthorizationModel model);
}
