using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Configuration;
using WebAPIShopStudy.Persistence.JWT.Interfaces;
using WebAPIShopStudy.Models.Entities;

namespace WebAPIShopStudy.Persistence.JWT.Implementation;

public class JwtGenerator : IJwtGenerator {

    private readonly IJwtConfiguration _configuration;

    public JwtGenerator(IJwtConfiguration configuration) {
        _configuration = configuration;
    }

    public string GenerateJwt(UserModel user) {
        var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var tokenDescriptor = _configuration.SecurityTokenDescriptor;
        tokenDescriptor.Subject = new ClaimsIdentity(claims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

}
