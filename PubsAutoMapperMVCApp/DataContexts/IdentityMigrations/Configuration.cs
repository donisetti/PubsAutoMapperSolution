namespace PubsAutoMapperMVCApp.DataContexts.IdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PubsAutoMapperMVCApp.DataContexts.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\IdentityMigrations";
        }

        protected override void Seed(PubsAutoMapperMVCApp.DataContexts.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "admin@a.com"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole { Name = "RAdmin" });

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "admin@a.com", Email = "admin@a.com", FavColor = "Blue", SecurityStamp = Guid.NewGuid().ToString() };
                userManager.Create(user, "Pass@word1");
                userManager.AddToRole(user.Id, "RAdmin");
            }

            #region Default
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            // 
            #endregion
        }
    }
}
