namespace ExamControl.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="ExamRegistration" />
    /// </summary>
    public class ExamRegistration
    {
        public ExamRegistration(Exam exam, DateTime registeredDateTime, string user)
        {
            Exam = exam;
            RegisteredDateTime = registeredDateTime;
            User = user;
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Exam
        /// </summary>
        public Exam Exam { get; set; }

        /// <summary>
        /// Gets or sets the RegisteredDateTime
        /// </summary>
        public DateTime RegisteredDateTime { get; set; }

        public string User { get; set; }
    }
}
