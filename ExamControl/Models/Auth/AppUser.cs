namespace ExamControl.Models.Auth
{
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Defines the <see cref="AppUser" />
    /// </summary>
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }

        public string StudentNumber { get; set; }
    }
}
