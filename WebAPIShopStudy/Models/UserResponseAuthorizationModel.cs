namespace WebAPIShopStudy.Models;

public class UserResponseAuthorizationModel {
    public string Login { get; set; } = "";
    public string JwtToken { get; set; } = "";
    public string Role { get; set; } = "";
}
