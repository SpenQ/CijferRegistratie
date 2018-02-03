using System.Security.Claims;

namespace CijferRegistratie.Models.Auth
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(ClaimsPrincipal principal)
        : base(principal)
        {
        }

        public string Name
        {
            get
            {
                return FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string Country
        {
            get
            {
                return FindFirst(ClaimTypes.Country).Value;
            }
        }
    }
}