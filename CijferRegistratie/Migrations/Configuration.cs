namespace CijferRegistratie.Migrations
{
    using CijferRegistratie.Models.Auth;
    using CijferRegistratie.Models.MVC;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole
                {
                    Name = "AppAdmin"
                };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@cijferregistratie.com"))
            {
                var store = new UserStore<AppUser>(context);
                var manager = new UserManager<AppUser>(store);
                var user = new AppUser
                {
                    UserName = "admin@cijferregistratie.com",
                    Name = "Admin",
                    Country = "The Netherlands"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "AppAdmin");
            }
        }
    }
}
