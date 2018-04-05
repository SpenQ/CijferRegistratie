using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ExamControl.Models.Exam
{
    public class InsertExamModel
    {
        [Display(Name = "Computerlokaal benodigd")]
        public bool ExamNeedsComputers { get; set; }

        [Required]
        [Display(Name = "Aantal studenten")]
        public int EstimatedAmountOfStudents { get; set; }

        [Required]
        [Display(Name = "Uploaden")]
        public HttpPostedFileBase File { get; set; }

        [Display(Name = "Surveillant beschikbaar")]
        public bool ExamSurveillantAvailable { get; set; }

        [Required]
        [Display(Name = "Selecteer Vak")]
        public int SelectedExamSubject { get; set; }

        [Required]
        [Display(Name = "Tijdsduur benodigd (min)")]
        public int ExamDuration { get; set; }
    }
}