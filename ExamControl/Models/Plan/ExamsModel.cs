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
        public ExamsModel(Domain.Exam e)
        {
            SubjectName = e.Subject.Name;
        }

        public string SubjectName { get; set; }

        public int? SelectedClassroom { get; set; }
    }
}
