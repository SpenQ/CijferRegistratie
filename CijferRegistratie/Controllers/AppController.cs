namespace CijferRegistratie.Controllers
{
    using System.Web.Mvc;
    using CijferRegistratie.Models.Auth;

    /// <summary>
    /// Defines the <see cref="AppController" />
    /// </summary>
    public class AppController : Controller
    {
        /// <summary>
        /// Gets the CurrentUser
        /// </summary>
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser();
            }
        }
    }
}
