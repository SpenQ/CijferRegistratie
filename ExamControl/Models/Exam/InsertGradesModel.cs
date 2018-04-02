using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ExamControl.Models.Exam
{
    public class InsertGradesModel
    {
        public string AppUserFirstName { get; set; }

        [Required]
        public string AppUserLastName { get; set; }

        [Required]
        public decimal ExamRegistrationGrade { get; set; }

        public int ExamSubject { get; set; }

        [Required]
        public string StudentNumber { get; set; }
    }
}