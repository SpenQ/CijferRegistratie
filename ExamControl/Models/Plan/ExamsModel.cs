namespace ExamControl.Models.Plan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ExamsModel" />
    /// </summary>
    public class ExamsModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExamsModel"/> class.
        /// </summary>
        public ExamsModel(AppDbContext ctx, Domain.Exam e)
        {
            var examsList = ctx.Exams.Include("Subject").Where(ex => ex.Subject != null && ex.DateTime.HasValue);

            Exams = new List<Exam>();
            foreach (var ex in examsList)
            {
                ((List<Exam>)Exams).Add(new Exam()
                {
                    Id = ex.Id,
                    SubjectName = ex.Subject.Name,
                    StartTime = ex.DateTime.Value.ToString("s"),
                    EndTime = ex.DateTime.Value.Add(ex.Duration).ToString("s"),
                });
            }

            Id = e.Id;
            SubjectName = e.Subject.Name;
            Duration = e.Duration.TotalMinutes.ToString();
        }

        public int Id { get; set; }

        public string SubjectName { get; set; }

        public int? SelectedClassroom { get; set; }

        public string Duration { get; set; }

        public IEnumerable<Exam> Exams { get; set; }

        public class Exam
        {
            public int Id { get; set; }

            public string SubjectName { get; set; }

            public string StartTime { get; set; }

            public string EndTime { get; set; }
        }
    }
}
