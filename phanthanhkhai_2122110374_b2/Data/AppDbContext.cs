<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using phanthanhkhai_2122110374_b2.Model;
=======
﻿using phanthanhkhai_2122110374_b2.Model;
using Microsoft.EntityFrameworkCore;
using System;


>>>>>>> a1f9e34a94f441d7bab6de9059b0ebd972d3cb80

namespace phanthanhkhai_2122110374_b2.Data
{
    public class AppDbContext : DbContext
    {
<<<<<<< HEAD
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
                .HasOne(p => p.Category) // Mỗi Product có một Category
                .WithMany(c => c.Products) // Mỗi Category có nhiều Products
                .HasForeignKey(p => p.Cat_Id); // Cat_Id trong Product là khóa ngoại

            // Mối quan hệ giữa Order và User
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)  // Mỗi Order có một User
                .WithMany(u => u.Orders)  // Mỗi User có nhiều Orders
                .HasForeignKey(o => o.UserId); // UserId trong Order là khóa ngoại

            //// Mối quan hệ giữa Order và OrderDetail
            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Order) // Mỗi OrderDetail thuộc về một Order
            //    .WithMany(o => o.OrderDetails) // Một Order có nhiều OrderDetails
            //    .HasForeignKey(od => od.OrderId); // OrderId trong OrderDetail là khóa ngoại

        }
=======
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
>>>>>>> a1f9e34a94f441d7bab6de9059b0ebd972d3cb80
    }
}
