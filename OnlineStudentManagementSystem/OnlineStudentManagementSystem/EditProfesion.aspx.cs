using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class EditProfesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (tb_name.Text == "")
            {
                GetDefaultData();
            }
        }

        public readonly Context context = new Context();

        public void GetDefaultData()
        {
            string idString = Request.QueryString["id"];

            try
            {
                int id = Int32.Parse(idString);
                Profesion profesion = context.Profesions.FirstOrDefault(p => p.ProfesionId == id);

                tb_name.Text = profesion.ProfesionName;
            }
            catch
            {
                lbl_status.Text = "Something gets wrong :(";
            }
        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            string idStringforDelete = Request.QueryString["id"];
            int idforDelete = Int32.Parse(idStringforDelete);
            Profesion profesion = context.Profesions.FirstOrDefault(p => p.ProfesionId == idforDelete);

            context.Profesions.Remove(profesion);
            context.SaveChanges();
            Response.Redirect("AdminPanel.aspx?status=deletedProfesion");
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string idStringforUpdate = Request.QueryString["id"];
            int idforUpdate = Int32.Parse(idStringforUpdate);
            Profesion profesion = context.Profesions.FirstOrDefault(p => p.ProfesionId == idforUpdate);


            if (tb_name.Text != "")
            {
                profesion.ProfesionName = tb_name.Text;

                context.SaveChanges();
                Response.Redirect("AdminPanel.aspx?status=updatedProfesion");
            }
            else
            {
                lbl_status.Text = "Required fields can not be left blank.";
            }
        }
    }
}