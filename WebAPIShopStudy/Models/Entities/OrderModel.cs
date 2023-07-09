namespace WebAPIShopStudy.Models.Entities;

public class OrderModel : BaseModel {
    public DateTime AddDateTime { get; set; } = DateTime.Now;
    
    public UserModel Customer { get; set; } = new UserModel();
    public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
}