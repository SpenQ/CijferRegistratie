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

        /// <summary>
        /// Gets or sets a value indicating whether AvailableSurveillant
        /// </summary>
        public bool AvailableSurveillant { get; set; }

        /// <summary>
        /// Gets or sets the Attributes
        /// </summary>
        public KeyValuePair<string, string> Attributes { get; set; }
    }
}
