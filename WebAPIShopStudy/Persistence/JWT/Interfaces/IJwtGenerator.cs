using WebAPIShopStudy.Models.Entities;

namespace WebAPIShopStudy.Persistence.JWT.Interfaces;

public interface IJwtGenerator {

    public string GenerateJwt(UserModel user);
}
