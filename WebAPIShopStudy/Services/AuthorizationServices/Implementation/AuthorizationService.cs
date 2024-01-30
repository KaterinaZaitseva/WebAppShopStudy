using WebAPIShopStudy.Models;
using WebAPIShopStudy.Persistence.JWT.Interfaces;
using WebAPIShopStudy.Services.AuthorizationService.Interfaces;
using WebAPIShopStudy.Services.ModelServices.Interfaces;

namespace WebAPIShopStudy.Services.AuthorizationService.Implementation;

public class AuthorizationService : IAuthorizationService {

    public AuthorizationService(IJwtGenerator tokenGenerator, 
        IUserService userCrudService) {
        _tokenGenerator = tokenGenerator;
        _userCrudService = userCrudService;
    }


    private readonly IJwtGenerator _tokenGenerator;
    private readonly IUserService _userCrudService;


    public async Task<UserResponseAuthorizationModel> AuthorizeAsync(UserAuthorizationModel model) {
        var user = await _userCrudService.FirstOrDefaultAsync( u => 
            u.Login == model.Login && 
            u.Password == model.Password
        );

        if (user is null)
            throw new Exception("User not found");

        return new UserResponseAuthorizationModel{
            JwtToken = _tokenGenerator.GenerateJwt(user),
            Login = user.Login,
            Role = user.Role
        };
                 
    }
}
