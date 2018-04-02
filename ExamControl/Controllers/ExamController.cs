using System;
using System.Linq;
using System.Web.Mvc;
using ExamControl.Domain;
using ExamControl.Models;
using ExamControl.Models.Exam;

namespace ExamControl.Controllers
{
    public class ExamController : Controller
    {
        [Authorize(Roles = "Student")]
        public ActionResult RegisterExam()
        {
            ViewBag.ExamSubjects = new AppDbContext().Subjects
                .Select(s => new SelectListItem()
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                });

            return View(new RegisterExamModel());
        }

        //public ActionResult RegisterExam(int id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        [Authorize(Roles = "Student")]
        public ActionResult GetRegisterableExams(int selectedExamSubject)
        {
            var ctx = new AppDbContext();
            var model = new RegisterExamModel(ctx, selectedExamSubject);

            return PartialView(model);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult InsertExam()
        {
            ViewBag.ExamSubjects = new AppDbContext().Subjects
                    .Select(s => new SelectListItem()
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    });

            return View(new InsertExamModel());
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult InsertExam(InsertExamModel model)
        {
            var ctx = new AppDbContext();

            var subject = ctx.Subjects.SingleOrDefault(s => s.Id == model.SelectedExamSubject);

            if (subject == null)
            {
                throw new Exception("Subject does not exist.");
            }

            var insertExam = new Exam(null, subject, model.EstimatedAmountOfStudents, null, model.ExamNeedsComputers, model.ExamSurveillantAvailable, model.ExamDuration);

            ctx.Exams.Add(insertExam);

            ctx.SaveChanges();

            return RedirectToAction("InsertExam");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult InsertGrades()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Student,Teacher")]
        public ActionResult Overview()
        {
            if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("OverviewTeacher");
            }
            else if (User.IsInRole("Student"))
            {
                return RedirectToAction("OverviewStudent");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("OverviewAdmin");
            }
            else
            {
                return new HttpUnauthorizedResult();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult OverviewAdmin()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult OverviewTeacher()
        {
            var model = new OverviewTeacherModel(new AppDbContext());

            return View(model);
        }

        [Authorize(Roles = "Student")]
        public ActionResult OverviewStudent()
        {
            throw new NotImplementedException();
        }
    }
}