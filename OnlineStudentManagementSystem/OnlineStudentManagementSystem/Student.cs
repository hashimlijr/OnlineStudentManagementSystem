using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentSurname { get; set; }
        [Required]
        public string FatherNameOfStudent { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        // Profession
        
        public int ProfesionId { get; set; }

        // Courses
        public ICollection<Course> Courses { get; set; }

        // Grades
        public ICollection<Grade> Grades { get; set; }

        // Attendance
    }
}