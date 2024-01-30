using WebAPIShopStudy.Services.AuthorizationService.Implementation;
using WebAPIShopStudy.Services.AuthorizationService.Interfaces;
using WebAPIShopStudy.Services.CachedServices;
using WebAPIShopStudy.Services.CrudService.Implementation;
using WebAPIShopStudy.Services.CrudService.Interfaces;
using WebAPIShopStudy.Services.CrudServices.Implementation;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Extensions;

public static class AuthorizationServiceCollectionExtensions {

    public static IServiceCollection AddAuthorizationService(this IServiceCollection services) {
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();

        return services;
    }

}
