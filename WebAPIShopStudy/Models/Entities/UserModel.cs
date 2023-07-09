using StackExchange.Redis;
using System.Diagnostics.CodeAnalysis;

namespace WebAPIShopStudy.Models.Entities;

public class UserModel : BaseModel {
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public string Role { get; set; } = "user";

    public IEnumerable<OrderModel> Orders { get; set; } = new List<OrderModel>();
}
