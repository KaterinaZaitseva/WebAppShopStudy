using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Persistence.JWT.Interfaces;
using WebAPIShopStudy.Persistence.JWT.Implementation;
using WebAPIShopStudy.Services.CrudService.Interfaces;
using WebAPIShopStudy.Services.CrudService.Implementation;
using WebAPIShopStudy.Services.AuthorizationService.Interfaces;
using WebAPIShopStudy.Services.AuthorizationService.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>();
builder.Services.AddSingleton<IJwtConfiguration, JwtConfiguration>();
builder.Services.AddSingleton<IJwtGenerator, JwtGenerator>();
IJwtConfiguration jwtConfiguration = new JwtConfiguration();

builder.Services.
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

builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = "localhost";
    options.InstanceName = "local";
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(
    x => x.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()
);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();