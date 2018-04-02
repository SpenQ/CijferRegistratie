using System;
using System.Linq;
using System.Web.Mvc;
using ExamControl.Domain;
using ExamControl.Models;
using ExamControl.Models.InsertExam;
using ExamControl.Models.InsertGrades;

namespace ExamControl.Controllers
{
    public class ExamController : Controller
    {
        [Authorize(Roles = "Student")]
        public ActionResult RegisterExam()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult InsertExam()
        {
            var model = new InsertExamModel();

            ViewBag.ExamSubjects = new AppDbContext().Subjects
                    .Select(s => new SelectListItem()
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    });

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult InsertExam(InsertExamModel model)
        {
            var ctx = new AppDbContext();

            var subject = ctx.Subjects.Where(s => s.Id == model.SelectedExamSubject).SingleOrDefault();

            if (subject == null)
            {
                throw new Exception("Subject does not exist.");
            }

            var insertExam = new Exam(null, subject, model.EstimatedAmountOfStudents, null, model.ExamNeedsComputers, model.ExamSurveillantAvailable);

            ctx.Exams.Add(insertExam);

            ctx.SaveChanges();

            return RedirectToAction("InsertExam");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult InsertGrades(InsertGradesModel model)
        {
            var ctx = new AppDbContext();

            var subject = ctx.Subjects.Where(s => s.Id == model.ExamSubject).SingleOrDefault();

            if (subject == null)
            {
                throw new Exception("Subject does not exist.");
            }

            //var insertGrades = new ExamRegistration(model.AppUserFirstName, model.AppUserLastName,model.ExamRegistrationGrade,model.ExamSubjectName, model.StudentNumber );

            ctx.ExamRegistrations.Add(insertGrades);

            ctx.SaveChanges();

            return RedirectToAction("InsertExam");
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
            var model = new OverviewTeacher(new AppDbContext());

            return View(model);
        }

        [Authorize(Roles = "Student")]
        public ActionResult OverviewStudent()
        {
            throw new NotImplementedException();
        }
    }
}