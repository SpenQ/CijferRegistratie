namespace ExamControl.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ExamControl.Models;
    using ExamControl.Models.Plan;

    /// <summary>
    /// Defines the <see cref="PlanController" />
    /// </summary>
    public class PlanController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var ctx = new AppDbContext();

            var model = new IndexModel(ctx);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Exams(int id)
        {
            var ctx = new AppDbContext();

            var exam = ctx.Exams.Include("Subject").Where(e => e.Id == id).SingleOrDefault();

            if (exam == null || exam.Subject == null)
            {
                return new HttpUnauthorizedResult();
            }

            var model = new ExamsModel(exam);

            ViewBag.Classrooms = ctx.Classrooms.Select(c => new SelectListItem() { Text = c.Code, Value = c.Id.ToString() });

            return View(model);
        }

        public ActionResult GetScheduleForClassroom(int selectedClassroom)
        {
            return PartialView();
        }
    }
}
