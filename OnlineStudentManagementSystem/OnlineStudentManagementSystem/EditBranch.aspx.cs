using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class EditBranch : System.Web.UI.Page
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
            string idString = Session["user"].ToString();

            try
            {
                int id = Int32.Parse(idString);
                Branch branch = context.Branches.FirstOrDefault(b => b.BranchId == id);

                tb_name.Text = branch.BranchName;
                
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

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string idStringforUpdate = Session["user"].ToString();

            int idforUpdate = Int32.Parse(idStringforUpdate);
            Branch branch = context.Branches.FirstOrDefault(b => b.BranchId == idforUpdate);

            if (tb_name.Text != "")
            {
                branch.BranchName = tb_name.Text;

                context.SaveChanges();
                Response.Redirect("AdminPanel.aspx?status=updatedBranch");
            }
            else
            {
                lbl_status.Text = "Required fields can not be left blank.";
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            string idStringforDelete = Session["user"].ToString();

            int idforDelete = Int32.Parse(idStringforDelete);
            Branch branch = context.Branches.FirstOrDefault(b => b.BranchId == idforDelete);

            context.Branches.Remove(branch);
            context.SaveChanges();
            Response.Redirect("AdminPanel.aspx?status=deletedBranch");
        }
    }
}