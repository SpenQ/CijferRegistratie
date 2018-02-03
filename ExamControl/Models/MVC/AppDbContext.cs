namespace ExamControl.Models.MVC
{
    using ExamControl.Models.Auth;
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
            : base("ExamControl.Properties.Settings.ConnectionString")
        {
        }
    }
}
