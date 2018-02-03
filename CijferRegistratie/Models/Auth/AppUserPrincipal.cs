using System.Security.Claims;

namespace CijferRegistratie.Models.Auth
{
    public class AppUserPrincipal : ClaimsPrincipal
    {
        public AppUserPrincipal(ClaimsPrincipal principal)
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