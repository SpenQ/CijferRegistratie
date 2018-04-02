using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExamControl.Models.Exam
{
    public class RegisterExamModel
    {
        public RegisterExamModel() { }

        public RegisterExamModel(AppDbContext ctx, int selectedExamSubject)
        {
            SelectedExamSubject = selectedExamSubject;

            Exams = ctx.Exams
                .Where(e => e.Subject.Id == selectedExamSubject
                            && e.DateTime.HasValue
                            && e.DateTime.Value > DateTime.Now)
                .Select(e => new Exam()
                {
                    ExamId = e.Id,
                    ExamDateTime = e.DateTime.Value,
                    ClassroomCode = e.Classroom.Code,
                    ExamDuration = e.Duration
                });
        }

        public IEnumerable<Exam> Exams { get; set; }

        [Display(Name = "Selecteer vak")]
        public int SelectedExamSubject { get; set; }

        public class Exam
        {
            public int ExamId { get; set; }

            public DateTime ExamDateTime { get; set; }

            public string ClassroomCode { get; set; }

            public TimeSpan ExamDuration { get; set; }
        }
    }
}