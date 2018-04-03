namespace ExamControl.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using ExamControl.Models.Auth;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    /// <summary>
    /// Defines the <see cref="AuthController" />
    /// </summary>
    [AllowAnonymous]
    public class AuthController : Controller
    {
        /// <summary>
        /// Defines the userManager
        /// </summary>
        private readonly UserManager<AppUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        public AuthController()
        : this(Startup.UserManagerFactory.Invoke())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userManager">The <see cref="UserManager{AppUser}"/></param>
        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Auth/LogIn
        /// <summary>
        /// The LogIn
        /// </summary>
        /// <param name="returnUrl">The <see cref="string"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        // POST: Auth/LogIn
        /// <summary>
        /// The LogIn
        /// </summary>
        /// <param name="model">The <see cref="LogInModel"/></param>
        /// <returns>The <see cref="Task{ActionResult}"/></returns>
        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                await SignIn(user);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user auth failed
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View();
        }

        // GET: Auth/LogOut
        /// <summary>
        /// The LogOut
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The <see cref="bool"/></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The SignIn
        /// </summary>
        /// <param name="user">The <see cref="AppUser"/></param>
        /// <returns>The <see cref="Task"/></returns>
        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            GetAuthenticationManager().SignIn(identity);
        }

        /// <summary>
        /// The GetAuthenticationManager
        /// </summary>
        /// <returns>The <see cref="IAuthenticationManager"/></returns>
        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        /// <summary>
        /// The GetRedirectUrl
        /// </summary>
        /// <param name="returnUrl">The <see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}
