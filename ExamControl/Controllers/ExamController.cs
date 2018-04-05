using System;
using System.Linq;
using System.Web.Mvc;
using ExamControl.Domain;
using ExamControl.Models;
using ExamControl.Models.Exam;
using Microsoft.AspNet.Identity;

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

        [Authorize(Roles = "Student")]
        public ActionResult RegisterForExam(int id)
        {
            var ctx = new AppDbContext();

            var exam = ctx.Exams.SingleOrDefault(e => e.Id == id);

            if (exam == null
                || !exam.DateTime.HasValue
                || exam.DateTime.Value < DateTime.Now)
            {
                return new HttpUnauthorizedResult();
            }

            var registration = new ExamRegistration(exam, User.Identity.GetUserId(), DateTime.Now);
            ctx.ExamRegistrations.Add(registration);
            ctx.SaveChanges();

            return RedirectToAction("RegisterExam");
        }

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

            var insertExam = new Exam(null, subject, model.EstimatedAmountOfStudents, null, model.ExamNeedsComputers, model.ExamSurveillantAvailable, new TimeSpan(0, model.ExamDuration, 0));

            ctx.Exams.Add(insertExam);

            ctx.SaveChanges();

            return RedirectToAction("InsertExam");
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult InsertGrades()
        {
            ViewBag.ExamSubjects = new AppDbContext().Exams
                    .Where(e => e.DateTime.HasValue
                    && e.DateTime.Value < DateTime.Now)
                    .Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Subject.Name
                    });

            var model = new InsertGradesModel();

            return View(model);
        }

        public ActionResult GetInsertableGradeRegistrations(int selectedExamSubject)
        {
            var ctx = new AppDbContext();

            var model = new InsertGradesModel(ctx, selectedExamSubject);

            return PartialView(model);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult InsertGrades(InsertGradesModel model)
        {
            throw new NotImplementedException();

            //var ctx = new AppDbContext();

            //var subject = ctx.Subjects.SingleOrDefault(s => s.Id == model.ExamSubject);

            //if (subject == null)
            //{
            //    throw new Exception("Subject does not exist.");
            //}

            //var insertGrades = new ExamRegistration(model.AppUserFirstName, model.AppUserLastName,model.ExamRegistrationGrade,model.ExamSubjectName, model.StudentNumber );

            //ctx.ExamRegistrations.Add(insertGrades);

            //ctx.SaveChanges();

            //return RedirectToAction("InsertExam");
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