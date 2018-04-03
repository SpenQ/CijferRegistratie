using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamControl.Models.Exam
{
    public class InsertGradesModel
    {
        public InsertGradesModel() { }

        public InsertGradesModel(AppDbContext ctx, int selectedExamSubject)
        {
            SelectedExamSubject = selectedExamSubject;

            Registrations = ctx.ExamRegistrations
                .Where(er => er.Exam.Subject.Id == selectedExamSubject
                && er.Exam.DateTime.HasValue
                && er.Exam.DateTime.Value < DateTime.Now)
                .Select(er => new ExamRegistration()
                {
                    ExamRegistrationId = er.Id,
                    ExamSubjectName = er.Exam.Subject.Name,
                    StudentName = "x",
                    StudentNumber = "x"
                });
        }

        public int SelectedExamSubject { get; set; }

        public IEnumerable<ExamRegistration> Registrations { get; set; }

        public class ExamRegistration
        {
            public int ExamRegistrationId { get; set; }

            public string ExamSubjectName { get; set; }

            public string StudentName { get; set; }

            public string StudentNumber { get; set; }

            public int? ExamRegistrationGrade { get; set; }
        }
    }
}