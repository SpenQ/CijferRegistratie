namespace CijferRegistratie.Models.MVC
{
    using CijferRegistratie.Models.Auth;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Defines the <see cref="AppDbContext" />
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        public AppDbContext()
            : base("CijferRegistratie.Properties.Settings.ConnectionString")
        {
        }
    }
}
