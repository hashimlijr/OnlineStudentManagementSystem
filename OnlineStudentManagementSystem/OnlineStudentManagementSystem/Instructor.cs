using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        [Required]
        public string InstructorName { get; set; }
        [Required]
        public string InstructorSurname { get; set; }
        [Required]
        public string FatherNameOfInstructor { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public int BranchId { get; set; }
        [Required]
        public string Email { get; set; }
        //public byte[] Photo { get; set; }
        [Required]
        public string Password { get; set; }

        // Courses
        public ICollection<Course> Courses { get; set; }
    }
}