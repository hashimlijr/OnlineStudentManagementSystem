using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["user"] != null)
            {
                Response.Redirect("IndexAfterLogin.aspx");
            }
        }
        public Context context = new Context();

        protected void btn_SignIn_Click(object sender, EventArgs e)
        {            
            Response.Redirect("Login.aspx");
        }
    }
}