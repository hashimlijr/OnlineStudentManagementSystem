using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }

        // Instructors
        public int InstructorId { get; set; }

        // Students
        public ICollection<Student> Students { get; set; }

        public Student Student { get; set; }
        
        // Grade
        public ICollection<Grade> Grades { get; set; }

        public Grade Grade { get; set; }
    }
}