using Microsoft.IdentityModel.Tokens;

namespace WebAPIShopStudy.Persistence.JWT.Interfaces;

public interface IJwtConfiguration {
    public string Issuer { get; }
    public string Audience { get; }
    public string SecretKey { get; }
    public SigningCredentials SigningCredentials { get; }
    public SecurityTokenDescriptor SecurityTokenDescriptor { get; }
}
