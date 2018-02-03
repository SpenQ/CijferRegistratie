namespace CijferRegistratie.Models.Auth
{
    using System.Security.Claims;

    /// <summary>
    /// Defines the <see cref="AppUserPrincipal" />
    /// </summary>
    public class AppUserPrincipal : ClaimsPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppUserPrincipal"/> class.
        /// </summary>
        /// <param name="principal">The <see cref="ClaimsPrincipal"/></param>
        public AppUserPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        /// <summary>
        /// Gets the Name
        /// </summary>
        public string Name
        {
            get
            {
                return FindFirst(ClaimTypes.Name).Value;
            }
        }

        /// <summary>
        /// Gets the Country
        /// </summary>
        public string Country
        {
            get
            {
                return FindFirst(ClaimTypes.Country).Value;
            }
        }
    }
}
