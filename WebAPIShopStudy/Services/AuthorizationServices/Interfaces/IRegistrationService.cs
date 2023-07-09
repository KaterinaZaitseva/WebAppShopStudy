using WebAPIShopStudy.Models;

namespace WebAPIShopStudy.Services.AuthorizationService.Interfaces;

public interface IRegistrationService {

    public Task RegisterAsync(UserRegistrationModel model);
}
