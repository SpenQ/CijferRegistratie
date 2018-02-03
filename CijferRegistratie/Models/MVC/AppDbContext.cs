using CijferRegistratie.Models.Auth;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CijferRegistratie.Models.MVC
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("CijferRegistratie.Properties.Settings.ConnectionString")
        {
        }
    }
}