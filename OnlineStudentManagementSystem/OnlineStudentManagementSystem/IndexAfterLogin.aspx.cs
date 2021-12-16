using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class IndexAfterLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public readonly Context context = new Context();
        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }

        public string CheckUser(string email)
        {
            var registeredAdmin = context.Admins.FirstOrDefault(rm => rm.Email.Equals(email));
            var registeredStudent = context.Students.FirstOrDefault(i => i.Email.Equals(email));
            var registeredInstructor = context.Instructors.FirstOrDefault(i => i.Email.Equals(email));


            if (registeredAdmin != null)
            {
                return "admin";
            }
            else if(registeredStudent != null)
            {
                return "student";
            }
            else if(registeredInstructor != null)
            {
                return "instructor";
            }
            else
            {
                return "not found";
            }
        }
        protected void btn_Return_Click(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            string status = CheckUser(email);

            switch (status)
            {
                case "admin": Response.Redirect("AdminPanel.aspx"); return;
                case "student": Response.Redirect("StudentDashboard.aspx"); return;
                case "instructor": Response.Redirect("InstructorDashboard.aspx"); return;
                case "not found": Response.Redirect("Index.aspx"); return;
            }



        }
    }
}