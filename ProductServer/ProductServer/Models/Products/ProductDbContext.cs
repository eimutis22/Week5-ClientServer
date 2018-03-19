namespace ProductServer
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductDbContext : DbContext
    {
        public ProductDbContext(): base("name=ProductDbContext")
        {
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}