using Microsoft.AspNet.Identity.EntityFramework;

namespace CijferRegistratie.Models.Auth
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }

        public string Country { get; set; }
    }
}