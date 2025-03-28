using phanthanhkhai_2122110374_b2.Model;
using Microsoft.EntityFrameworkCore;
using System;



namespace phanthanhkhai_2122110374_b2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
