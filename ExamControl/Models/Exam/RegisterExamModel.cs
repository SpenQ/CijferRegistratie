using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamControl.Models.Exam
{
    public class RegisterExamModel
    {
        [Required]
        public DateTime ExamDateTime { get; set; }

        [Required]
        public TimeSpan ExamDuration { get; set; }

        public string ClassroomCode { get; set; }

        [Required]
        public int ExamSubject { get; set; }
    }
}