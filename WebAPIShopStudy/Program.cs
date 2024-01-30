using WebAPIShopStudy.Extensions;
using WebAPIShopStudy.Persistence;
using WebAPIShopStudy.Persistence.JWT.Implementation;
using WebAPIShopStudy.Persistence.JWT.Interfaces;
using WebAPIShopStudy.Services.EmailServices.Implementation;
using WebAPIShopStudy.Services.EmailServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>();

//builder.Services.AddHostedService<HostedService>();

IJwtConfiguration jwtConfiguration = new JwtConfiguration();

builder.Services.AddTokenService(jwtConfiguration);

builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddModelsService();
builder.Services.AddAuthorizationService();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddRedisService(builder.Configuration.GetSection("RedisSettings"));

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