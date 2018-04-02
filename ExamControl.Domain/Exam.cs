﻿namespace ExamControl.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Exam" />
    /// </summary>
    public class Exam
    {
        public Exam(DateTime? dateTime, Subject subject, int estimatedAmountOfStudents, Classroom classroom, bool needsComputers)
        {
            DateTime = dateTime;
            Subject = subject;
            EstimatedAmountOfStudents = estimatedAmountOfStudents;
            Classroom = classroom;
            NeedsComputers = needsComputers;
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the DateTime
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Gets or sets the Subject
        /// </summary>
        public Subject Subject { get; set; }

        /// <summary>
        /// Gets or sets the EstimatedAmountOfStudents
        /// </summary>
        public int EstimatedAmountOfStudents { get; set; }

        public Classroom Classroom { get; set; }

        public bool NeedsComputers { get; set; }
    }
}
