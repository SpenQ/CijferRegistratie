namespace CijferRegistratie.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="HomeController" />
    /// </summary>
    public class HomeController : AppController
    {
        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The About
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// The Contact
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
