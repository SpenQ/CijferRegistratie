using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamControl.Models.Exam
{
    public class InsertExamModel
    {
        public bool ClassroomHasComputers { get; set; }

        [Required]
        public uint EstimatedAmountOfStudents { get; set; }

        [Required]
        public HttpPostedFileBase File { get; set; }

        public bool ExamRegistrationSurveillantAvailable { get; set; }

        [Required]
        public int ExamSubject { get; set; }
    }
}