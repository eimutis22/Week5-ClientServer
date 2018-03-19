namespace ProductServer.Models.Products
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductDbContext : DbContext
    {
        public ProductDbContext(): base("name=ProductDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}