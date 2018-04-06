namespace ExamControl.Models.Plan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="IndexModel" />
    /// </summary>
    public class IndexModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        public IndexModel(AppDbContext ctx)
        {
            var examList = ctx.Exams.Include("Subject")
                .Where(e => !e.DateTime.HasValue || e.Classroom == null);

            Exams = new List<Exam>();

            foreach (var ex in examList)
            {
                ((List<Exam>)Exams).Add(new Exam(ex));
            }

            //Exams = ctx.Exams
            //    .Where(e => (!e.DateTime.HasValue || e.Classroom == null) && e.Subject == null)
            //    .Select(e => new Exam(e))
            //    .ToArray();
        }

        /// <summary>
        /// Gets or sets the Exams
        /// </summary>
        public IEnumerable<Exam> Exams { get; set; }

        public class Exam
        {
            public Exam(Domain.Exam e)
            {
                Id = e.Id;
                SubjectName = e.Subject?.Name;
                EstimatedAmountOfStudents = e.EstimatedAmountOfStudents;
                NeedsComputers = e.NeedsComputers;
                SurveillantAvailable = e.SurveillantAvailable;
                Duration = e.Duration.TotalMinutes.ToString();
            }

            public int Id { get; set; }

            public string SubjectName { get; set; }

            public int EstimatedAmountOfStudents { get; set; }

            public bool NeedsComputers { get; set; }

            public bool SurveillantAvailable { get; set; }

            public string Duration { get; set; }
        }
    }
}
