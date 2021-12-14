using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class NewPassword : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        public readonly Context context = new Context();
        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            string idStringforUpdate = Session["user"].ToString();
            int idforUpdate = Int32.Parse(idStringforUpdate);

            Student student = context.Students.FirstOrDefault(s => s.StudentID == idforUpdate);
            if(tb_password.Text != "" && tb_coPassword.Text != "")
            {
                if(tb_password.Text == tb_coPassword.Text)
                {
                    student.Password = tb_password.Text;
                    context.SaveChanges();
                    lbl_status.Text = "Password has been changed successfully";
                    Session["user"] = null;
                    Response.Redirect("Index.aspx");
                }
                else
                {

                    lbl_status.Text = "Passwords don't match";
                }
            }
            else
            {
                lbl_status.Text = "Please fill required fields";
            }
        }

        protected void btn_ToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}