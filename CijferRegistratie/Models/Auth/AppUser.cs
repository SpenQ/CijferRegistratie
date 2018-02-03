namespace CijferRegistratie.Models.Auth
{
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Defines the <see cref="AppUser" />
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        public string Country { get; set; }
    }
}
