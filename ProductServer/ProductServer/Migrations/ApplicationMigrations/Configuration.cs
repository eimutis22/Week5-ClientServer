namespace ProductServer.Migrations.ApplicationMigrations
{
    using ProductServer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductServer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationMigrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(
              p => p.Id,
              new ApplicationUser { UserName = "fflynstone", Email= "Flintstone.fred@itsligo.ie", PasswordHash= "Flint$12345" }
            );
        }
    }
}
