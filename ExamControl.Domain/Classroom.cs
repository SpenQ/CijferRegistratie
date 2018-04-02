namespace ExamControl.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Classroom
    {   /// <summary>
        /// Gets or sets the Uint32
        /// </summary>
        public uint AmmountOfSeats { get; set; }
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
