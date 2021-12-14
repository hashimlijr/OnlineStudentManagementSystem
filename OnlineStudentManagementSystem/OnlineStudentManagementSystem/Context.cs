using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Context:DbContext
    {
        public Context() : base("StudentMS")
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Profesion> Profesions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<ResetCode> ResetCodes { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}