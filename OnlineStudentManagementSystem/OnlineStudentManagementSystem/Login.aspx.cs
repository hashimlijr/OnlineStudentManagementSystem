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
        public bool CheckLogin(Student s)
        {
            var registeredUser = context.Students.FirstOrDefault(i => i.Email.Equals(s.Email) && i.Password.Equals(s.Password));

            if(registeredUser == null)
            {
                return false;
            }

            return true;
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

                if (CheckLogin(loginStudent))
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    lbl_status.Text = "Student couldn't be found. Please check email and password again";
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