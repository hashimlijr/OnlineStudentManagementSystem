using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        // CourseID
        [Required]
        public int CourseID { get; set; }

        // StudentID
        [Required]
        public int StudentID { get; set; }

        [Required]
        public int GradeScore { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}