namespace ExamControl.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Exam" />
    /// </summary>
    public class Exam
    {
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
        /// Gets or sets the Attributes
        /// </summary>
        public KeyValuePair<string, string> Attributes { get; set; }
    }
}
