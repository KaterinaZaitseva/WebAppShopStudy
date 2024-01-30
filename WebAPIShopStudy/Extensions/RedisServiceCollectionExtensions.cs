using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPIShopStudy.Persistence.JWT.Implementation;
using WebAPIShopStudy.Persistence.JWT.Interfaces;

namespace WebAPIShopStudy.Extensions;

public static class RedisServiceCollectionExtensions {

    public static IServiceCollection AddRedisService(this IServiceCollection services, IConfiguration configuration) {

        services.AddStackExchangeRedisCache(options => {
            options.Configuration = configuration["Configuration"];
            options.InstanceName = configuration["InstanceName"];
        });

        return services;
    }

}
