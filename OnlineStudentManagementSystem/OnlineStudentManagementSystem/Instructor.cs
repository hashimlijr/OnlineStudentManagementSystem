using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Instructor
    {
        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
        public string InstructorSurname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfesionOfInstructor { get; set; }
        public string Email { get; set; }
        //public byte[] Photo { get; set; }
        public string Password { get; set; }

        // Courses
    }
}