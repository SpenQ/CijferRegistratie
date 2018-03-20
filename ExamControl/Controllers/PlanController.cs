namespace ExamControl.Controllers
{
    using System.Web.Mvc;
    using ExamControl.Models.Plan;

    /// <summary>
    /// Defines the <see cref="PlanController" />
    /// </summary>
    public class PlanController : Controller
    {
        // GET: Plan
        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = new IndexModel();
            return View(model);
        }
    }
}
