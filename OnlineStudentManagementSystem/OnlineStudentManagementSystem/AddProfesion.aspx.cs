using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class AddProfesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }

        public readonly Context context = new Context();

        public void ClearFields()
        {
            tb_name.Text = "";
        }


        public bool CheckingProfesionDoesntExists(Profesion p)
        {
            var oldProfesion = context.Profesions.FirstOrDefault(op => op.ProfesionName == p.ProfesionName);
            if (oldProfesion != null)
                return false;
            return true;
        }

        protected void btn_addProfesion_Click(object sender, EventArgs e)
        {
            string name = tb_name.Text.Trim();

            if (name != "")
            {
                Profesion profesion = new Profesion()
                {
                    ProfesionName = name,
                };

                if (CheckingProfesionDoesntExists(profesion))
                {
                    context.Profesions.Add(profesion);
                    context.SaveChanges();

                    lbl_status.Text = "Profesion was added successfully.";

                    ClearFields();
                }
                else
                {
                    lbl_status.Text = "This profesion already exists.";
                }
            }
            else
            {
                lbl_status.Text = "Please fill all required fields.";
            }
        }
    }
}