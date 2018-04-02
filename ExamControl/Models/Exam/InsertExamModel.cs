using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ExamControl.Models.Exam
{
    public class InsertExamModel
    {
        public bool ExamNeedsComputers { get; set; }

        [Required]
        public int EstimatedAmountOfStudents { get; set; }

        [Required]
        public HttpPostedFileBase File { get; set; }

        public bool ExamSurveillantAvailable { get; set; }

        [Required]
        public int SelectedExamSubject { get; set; }

        [Required]
        public TimeSpan ExamDuration { get; set; }
    }
}