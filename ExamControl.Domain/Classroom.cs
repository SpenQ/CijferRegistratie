namespace ExamControl.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class Classroom
    {
        public Classroom(int amountOfSeats, bool hasComputers, string code)
        {
            AmountOfSeats = amountOfSeats;
            HasComputers = hasComputers;
            Code = code;
        }

        /// <summary>
        /// Gets or sets the Int32
        /// </summary>
        public int AmountOfSeats { get; set; }

        /// <summary>
        /// Gets or sets the Boolean
        /// </summary>
        public bool HasComputers { get; set; }

        /// <summary>
        /// Gets or sets the Int32
        /// </summary>
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }
    }
}
