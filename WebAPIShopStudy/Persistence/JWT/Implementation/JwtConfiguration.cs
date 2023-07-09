using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPIShopStudy.Persistence.JWT.Interfaces;

namespace WebAPIShopStudy.Persistence.JWT.Implementation;

public class JwtConfiguration : IJwtConfiguration {

    public JwtConfiguration() {

        IConfiguration _configuration = new ConfigurationBuilder()
            .AddJsonFile("tokenconfiguration.json", true, true)
            .Build();

        Issuer = _configuration["JwtSettings:Issuer"]!;
        Audience = _configuration["JwtSettings:Audience"]!;
        SecretKey = _configuration["JwtSettings:SecretKey"]!;

        SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(SecretKey)
            ),
            SecurityAlgorithms.HmacSha256
        );

        SecurityTokenDescriptor = new SecurityTokenDescriptor {
            Issuer = Issuer,
            Audience = Audience,
            SigningCredentials = SigningCredentials
        };
    }

    public string Issuer { get; }
    public string Audience { get; }
    public string SecretKey { get; }
    public SigningCredentials SigningCredentials { get; }
    public SecurityTokenDescriptor SecurityTokenDescriptor { get; }

}
