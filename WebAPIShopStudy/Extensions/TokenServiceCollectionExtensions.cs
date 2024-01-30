using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPIShopStudy.Persistence.JWT.Implementation;
using WebAPIShopStudy.Persistence.JWT.Interfaces;

namespace WebAPIShopStudy.Extensions;

public static class TokenServiceCollectionExtensions {

    public static IServiceCollection AddTokenService(this IServiceCollection services, IJwtConfiguration jwtConfiguration) {
        services.AddSingleton<IJwtConfiguration, JwtConfiguration>();
        services.AddSingleton<IJwtGenerator, JwtGenerator>();

        services.
            AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters() {
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidAudience = jwtConfiguration.Audience,
                    IssuerSigningKey = jwtConfiguration.SigningCredentials.Key,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

        return services;
    }

}