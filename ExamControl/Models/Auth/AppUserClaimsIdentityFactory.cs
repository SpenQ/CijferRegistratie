namespace ExamControl.Models.Auth
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    /// <summary>
    /// Defines the <see cref="AppUserClaimsIdentityFactory" />
    /// </summary>
    public class AppUserClaimsIdentityFactory : ClaimsIdentityFactory<AppUser>
    {
        /// <summary>
        /// The CreateAsync
        /// </summary>
        /// <param name="manager">The <see cref="UserManager{AppUser}"/></param>
        /// <param name="user">The <see cref="AppUser"/></param>
        /// <param name="authenticationType">The <see cref="string"/></param>
        /// <returns>The <see cref="Task{ClaimsIdentity}"/></returns>
        public async Task<ClaimsIdentity> CreateAsync(
        UserManager<AppUser> manager,
        AppUser user,
        string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);

            return identity;
        }
    }
}
