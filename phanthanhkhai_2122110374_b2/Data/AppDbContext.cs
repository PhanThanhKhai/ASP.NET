using phanthanhkhai_2122110374_b2.Model;
using Microsoft.EntityFrameworkCore;
using System;



namespace phanthanhkhai_2122110374_b2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
<<<<<<< HEAD
        public DbSet<Category> Categories { get; set; }
=======
>>>>>>> d39b22ae12239411158412d3a5fbfc8c635d7abf
    }
}
