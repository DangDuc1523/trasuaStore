using Microsoft.EntityFrameworkCore;
using TraSuaMoc.API.Models;

namespace TraSuaMoc.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<AdminUser> AdminUsers => Set<AdminUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seed menu items
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id=1, Name="Trà Sữa Oolong", Description="Trà oolong thơm, sữa tươi béo ngậy", Price=35000, Emoji="🧋", Category="trasua", IsHot=true },
            new MenuItem { Id=2, Name="Trà Sữa Matcha", Description="Matcha Nhật nguyên chất hoà cùng sữa tươi", Price=38000, Emoji="🍵", Category="trasua", IsNew=true },
            new MenuItem { Id=3, Name="Trà Sữa Dâu", Description="Dâu tây tươi xay nhuyễn, sữa tươi, trân châu đỏ", Price=37000, Emoji="🍓", Category="trasua" },
            new MenuItem { Id=4, Name="Trà Sữa Taro", Description="Khoai môn tím thuần chất, vị bùi ngọt đặc trưng", Price=38000, Emoji="💜", Category="trasua", IsHot=true },
            new MenuItem { Id=5, Name="Cà Phê Sữa Đá", Description="Cà phê phin truyền thống, sữa đặc ngọt thơm", Price=28000, Emoji="☕", Category="cafe" },
            new MenuItem { Id=6, Name="Bạc Xỉu", Description="Cà phê nhẹ, nhiều sữa, thích hợp buổi chiều", Price=28000, Emoji="🥛", Category="cafe" },
            new MenuItem { Id=7, Name="Cold Brew", Description="Ủ lạnh 12 giờ, hương thơm đậm đà, không đắng", Price=35000, Emoji="🧊", Category="cafe", IsHot=true },
            new MenuItem { Id=8, Name="Sinh Tố Bơ", Description="Bơ chín 100%, thêm sữa đặc và đá xay mịn", Price=40000, Emoji="🥑", Category="sinh-to" },
            new MenuItem { Id=9, Name="Sinh Tố Xoài", Description="Xoài cát Hoà Lộc ngọt lịm, đá xay mát lạnh", Price=38000, Emoji="🥭", Category="sinh-to", IsNew=true },
            new MenuItem { Id=10, Name="Nước Ép Cam", Description="Cam vắt tươi mỗi ngày, vitamin C dồi dào", Price=32000, Emoji="🍊", Category="nuoc-ep" },
            new MenuItem { Id=11, Name="Nước Ép Dưa Hấu", Description="Dưa hấu mùa hè tươi ngọt, mát lạnh sảng khoái", Price=30000, Emoji="🍉", Category="nuoc-ep" },
            new MenuItem { Id=12, Name="Trà Đào Cam Sả", Description="Kết hợp đào, cam và sả, vị chua ngọt dịu mát", Price=33000, Emoji="🍑", Category="tra", IsHot=true },
            new MenuItem { Id=13, Name="Trà Chanh Leo", Description="Chanh dây nhiệt đới chua nhẹ, thơm mát", Price=30000, Emoji="🟡", Category="tra" }
        );

        // Seed admin user (password: admin123)
        modelBuilder.Entity<AdminUser>().HasData(
            new AdminUser { Id=1, Username="admin", PasswordHash=BCrypt.Net.BCrypt.HashPassword("admin123") }
        );
    }
}
