namespace CijferRegistratie.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CijferRegistratie.Models.Auth;
    using CijferRegistratie.Models.MVC;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Defines the <see cref="Configuration" />
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// The Seed
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/></param>
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
