using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using WebAPIShopStudy.Models.Entities;

namespace WebAPIShopStudy.Persistence;

public class CustomAuthorizeAttribute : AuthorizeAttribute {
    public CustomAuthorizeAttribute(Role roleEnum) {
        Roles = roleEnum.ToString().Replace(" ", string.Empty);
    }
}
