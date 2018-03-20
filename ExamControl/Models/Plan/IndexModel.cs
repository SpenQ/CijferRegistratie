namespace ExamControl.Models.Plan
{
    using System.Collections.Generic;
    using ExamControl.Domain;

    /// <summary>
    /// Defines the <see cref="IndexModel" />
    /// </summary>
    public class IndexModel
    {
        /// <summary>
        /// Defines the ctx
        /// </summary>
        private AppDbContext ctx = new AppDbContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        public IndexModel()
        {
            Exams = ctx.Exams;
        }

        /// <summary>
        /// Gets or sets the Exams
        /// </summary>
        public IEnumerable<Exam> Exams { get; set; }
    }
}
