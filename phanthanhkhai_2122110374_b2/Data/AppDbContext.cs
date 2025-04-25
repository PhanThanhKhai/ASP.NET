using Microsoft.EntityFrameworkCore;
using phanthanhkhai_2122110374_b2.Model;

namespace phanthanhkhai_2122110374_b2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mối quan hệ giữa Product và Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Cat_Id);

            // Mối quan hệ giữa Order và User
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            // Cấu hình kiểu decimal cho OrderDetail.Price
            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Price)
                .HasPrecision(18, 2); // hoặc dùng .HasColumnType("decimal(18,2)");

            // Mối quan hệ giữa Order và OrderDetail (nếu bạn muốn bật lại)
            // modelBuilder.Entity<OrderDetail>()
            //     .HasOne(od => od.Order)
            //     .WithMany(o => o.OrderDetails)
            //     .HasForeignKey(od => od.OrderId);
        }
    }
}
