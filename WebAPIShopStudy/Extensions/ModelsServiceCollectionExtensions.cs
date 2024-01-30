using WebAPIShopStudy.Services.CachedServices;
using WebAPIShopStudy.Services.CrudService.Implementation;
using WebAPIShopStudy.Services.CrudServices.Implementation;
using WebAPIShopStudy.Services.CrudServices.Interfaces;
using WebAPIShopStudy.Services.ModelServices.Interfaces;

namespace WebAPIShopStudy.Extensions;

public static class ModelsServiceCollectionExtensions {

    public static IServiceCollection AddModelsService(this IServiceCollection services) {
        services.AddScoped<ICachedService, CachedService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();

        return services;
    }

}
