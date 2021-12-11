using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public readonly Context context = new Context();

        public void ClearFields()
        {
            tb_name.Text = "";
            tb_surname.Text = "";
            tb_email.Text = "";
            tb_username.Text = "";
            tb_password.Text = "";
            tb_conpassword.Text = "";
        }

        public bool CheckingStudentDoesntExists(Student s)
        {
            var oldUser = context.Students.FirstOrDefault(ou => ou.Email == s.Email);
            if (oldUser != null)
                return false;
            return true;
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            string name = tb_name.Text.Trim();
            string surname = tb_surname.Text.Trim();
            string email = tb_email.Text.Trim();
            string username = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();
            string conpassword = tb_conpassword.Text.Trim();

            if(name != "" && surname != "" && email != "" && password != "" && conpassword != "")
            {
                if(password == conpassword)
                {
                    Student student = new Student()
                    {
                        StudentName = name,
                        StudentSurname = surname,
                        Email = email,
                        Password = password,
                    };

                    if (CheckingStudentDoesntExists(student))
                    {
                        context.Students.Add(student);
                        context.SaveChanges();

                        lbl_status.Text = "Student was added successfully.";

                        ClearFields();
                    }
                    else
                    {
                        lbl_status.Text = "This student already exists.";
                    }
                    
                }
                else
                {
                    lbl_status.Text = "Passwords don't match.";
                }
            }
            else
            {
                lbl_status.Text = "Please fill all fields.";
            }           
        }

        protected void btn_resetPassword_Click(object sender, EventArgs e)
        {
            Student studenttest = new Student()
            {
                StudentName = "StudentName",
                StudentSurname = "StudentSurname",
                Email = "email@gmail.com",
                Password = "password",
            };
            context.Students.Add(studenttest);

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

            Instructor instructor = new Instructor()
            {
                InstructorName = "InstructorName",
                InstructorSurname = "InstructorSurname",
                ProfesionOfInstructor = "ProfesionOfInstructor"
            };
            context.Instructors.Add(instructor);

            Grade grade = new Grade()
            {
                GradeScore = 98,
            };
            context.Grades.Add(grade);

            context.SaveChanges();
        }
    }
}