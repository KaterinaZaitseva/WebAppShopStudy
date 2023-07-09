using Microsoft.EntityFrameworkCore;
using WebAPIShopStudy.Models.Entities;

namespace WebAPIShopStudy.Persistence;

public class ShopDbContext : DbContext {
    public DbSet<UserModel> Users { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<OrderModel> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source=shop.db");
    }
}
