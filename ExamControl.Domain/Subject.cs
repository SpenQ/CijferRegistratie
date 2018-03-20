namespace ExamControl.Domain
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Subject" />
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }
    }
}
