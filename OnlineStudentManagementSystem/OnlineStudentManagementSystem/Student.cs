using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Profession

        // Courses

        // Grades

        // Attendance
    }
}