using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Context context = new Context();
        protected void btn_CreateDB_Click(object sender, EventArgs e)
        {
            Branch branch = new Branch()
            {
                BranchName = "BranchName",
            };
            context.Branches.Add(branch);

            Instructor instructor = new Instructor()
            {
                InstructorName = "InstructorName",
                InstructorSurname = "InstructorSurname",
                FatherNameOfInstructor = "FatherNameOfInstructor",
                Email = "instructor@gmail.com",
                Password = "instructor123",
            };
            context.Instructors.Add(instructor);

            Course course = new Course()
            {
                CourseName = "CourseName",
            };
            context.Courses.Add(course);

            Profesion profesion = new Profesion()
            {
                ProfesionName = "ProfesionName",
            };
            context.Profesions.Add(profesion);

            Student studenttest = new Student()
            {
                StudentName = "StudentName",
                StudentSurname = "StudentSurname",
                FatherNameOfStudent = "FatherNameOfStudent",
                Email = "email@gmail.com",
                Password = "password",
                ProfesionId = 1,
            };
            context.Students.Add(studenttest);

            

            //Grade grade = new Grade()
            //{
            //    StudentID = 1,
            //    CourseID = 1,
            //    GradeScore = 98,
            //};
            //context.Grades.Add(grade);

            context.SaveChanges();
        }

        protected void btn_AddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}