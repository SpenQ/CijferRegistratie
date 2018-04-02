using ExamControl.Domain;
using ExamControl.Models;
using ExamControl.Models.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamControl.Controllers
{
    public class ExamController : Controller
    {
        [Authorize(Roles = "Student")]
        public ActionResult RegisterExam()
        {
            ViewBag.ExamSubjects = new AppDbContext().Subjects.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() });

            return View();
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult InsertExam()
        {
            var model = new InsertExamModel();

            return View();
        }

        [HttpPost]
        public ActionResult InsertExam(InsertExamModel model)
        {
            var ctx = new AppDbContext();

            var insertExam = new Exam()
            {
                EstimatedAmountOfStudents = model.EstimatedAmountOfStudents
            };

            ctx.Exams.Add(insertExam);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult InsertGrades()
        {
            return View();
        }
    }
}