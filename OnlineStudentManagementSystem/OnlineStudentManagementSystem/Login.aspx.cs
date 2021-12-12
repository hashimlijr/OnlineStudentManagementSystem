using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_status.Visible = false;
        }
        public readonly Context context = new Context();
        public string CheckStudent(Student s)
        {
            var registeredStudent = context.Students.FirstOrDefault(i => i.Email.Equals(s.Email) && i.Password.Equals(s.Password));

            if (registeredStudent != null)
            {
                return "student";
            }
            else
            {
                return "notfound";
            }
        }
        public string CheckInstructor(Instructor ins)
        {
            var registeredInstructor = context.Instructors.FirstOrDefault(i => i.Email.Equals(ins.Email) && i.Password.Equals(ins.Password));

            if (registeredInstructor != null)
            {
                return "instructor";
            }
            else
            {
                return "notfound";
            }
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            string password = tb_password.Text;

            if(email != "" && password != "")
            {
                Student loginStudent = new Student()
                {
                    Email = email,
                    Password = password
                };

                Instructor loginInstructor = new Instructor()
                {
                    Email = email,
                    Password = password,
                };

                if (CheckStudent(loginStudent) == "student")
                {
                    Response.Redirect("Index.aspx");
                }
                else if(CheckInstructor(loginInstructor) == "instructor")
                {
                    Response.Redirect("InstructorDashboard.aspx");
                }
                else
                {
                    lbl_status.Text = "User couldn't be found. Please check email and password again";
                    lbl_status.Visible = true;
                }
            }
            else
            {
                lbl_status.Text = "Please fill all fields.";
                lbl_status.Visible = true;
            }
        }
    }
}