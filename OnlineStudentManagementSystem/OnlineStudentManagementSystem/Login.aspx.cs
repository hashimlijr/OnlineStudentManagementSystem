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
            if(Session["user"] != null)
            {
                Response.Redirect("Index.aspx");
            }
        }
        public readonly Context context = new Context();

        public string CheckAdmin(Admin a)
        {
            var registeredAdmin = context.Admins.FirstOrDefault(rm => rm.Email.Equals(a.Email) && rm.Password.Equals(a.Password));

            if (registeredAdmin != null)
            {
                return "admin";
            }
            else
            {
                return "notfound";
            }
        }
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
                Admin admin = new Admin
                {
                    Email = email,
                    Password = password,
                };

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
                if (CheckAdmin(admin) == "admin")
                {
                    int id = context.Admins.FirstOrDefault(a => a.Email == email).AdminID;
                    Session["user"] = id;
                    Session["email"] = email;
                    Response.Redirect("AdminPanel.aspx");
                }
                else if (CheckStudent(loginStudent) == "student")
                {
                    int id = context.Students.FirstOrDefault(s => s.Email == email).StudentID;
                    Session["user"] = id;
                    Session["email"] = email;
                    Response.Redirect("StudentDashboard.aspx?id=" + id);
                }
                else if(CheckInstructor(loginInstructor) == "instructor")
                {
                    string id = context.Instructors.FirstOrDefault(i => i.Email == email).InstructorID.ToString();
                    Session["user"] = id;
                    Session["email"] = email;
                    Response.Redirect("InstructorDashboard.aspx?id=" + id);
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

        protected void btn_ResetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassword.aspx");
        }
    }
}