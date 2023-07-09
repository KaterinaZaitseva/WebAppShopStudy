using System.Diagnostics.CodeAnalysis;

namespace WebAPIShopStudy.Models.Entities;

public class ProductModel : BaseModel {
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public string Description { get; set; } = "";
    public string PictureUrl { get; set; } = "https://img.freepik.com/free-vector/page-found-concept-illustration_114360-1869.jpg";
}