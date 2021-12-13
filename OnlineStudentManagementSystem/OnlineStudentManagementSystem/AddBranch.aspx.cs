using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class AddBranch : System.Web.UI.Page
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

        public bool CheckingBranchDoesntExists(Branch b)
        {
            var oldBranch = context.Branches.FirstOrDefault(ob => ob.BranchName == b.BranchName);
            if (oldBranch != null)
                return false;
            return true;
        }

        protected void btn_addBranch_Click(object sender, EventArgs e)
        {
            string name = tb_name.Text.Trim();

            if (name != "")
            {
                Branch branch = new Branch()
                {
                    BranchName = name,
                };

                if (CheckingBranchDoesntExists(branch))
                {
                    context.Branches.Add(branch);
                    context.SaveChanges();

                    lbl_status.Text = "Branch was added successfully.";

                    ClearFields();
                }
                else
                {
                    lbl_status.Text = "This branch already exists.";
                }
            }
            else
            {
                lbl_status.Text = "Please fill all required fields.";
            }
        }
    }
}