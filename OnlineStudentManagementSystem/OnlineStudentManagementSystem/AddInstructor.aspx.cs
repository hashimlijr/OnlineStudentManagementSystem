using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class AddInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var branches = context.Branches.ToList();
            foreach (var branch in branches)
            {
                var exist = DropDownList_Branch.Items.FindByValue(branch.BranchName);
                if(exist == null)
                {
                    DropDownList_Branch.Items.Add(branch.BranchName);
                }            
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }

        public readonly Context context = new Context();

        public void ClearFields()
        {
            tb_name.Text = "";
            tb_surname.Text = "";
            tb_email.Text = "";
            tb_password.Text = "";
            tb_conpassword.Text = "";
            tb_fatherName.Text = "";
            DropDownList_Branch.SelectedIndex = 0;
            tb_date.Text = "";
        }

        public bool CheckingInstructorDoesntExists(Instructor ins)
        {
            var oldUser = context.Instructors.FirstOrDefault(ou => ou.Email == ins.Email);
            if (oldUser != null)
                return false;
            return true;
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            string name = tb_name.Text.Trim();
            string surname = tb_surname.Text.Trim();
            string email = tb_email.Text.Trim();
            string fatherName = tb_fatherName.Text.Trim();
            string password = tb_password.Text.Trim();
            string conpassword = tb_conpassword.Text.Trim();
            string branchName = DropDownList_Branch.SelectedValue;
            string dateString = tb_date.Text.Trim();

            int branchId = context.Branches.FirstOrDefault(i => i.BranchName == branchName).BranchId;

            if (name != "" && surname != "" && email != "" && password != "" && conpassword != "" && fatherName != "" && dateString != "")
            {
                if (password == conpassword)
                {

                    DateTime date = Convert.ToDateTime(dateString);

                    Instructor instructor = new Instructor()
                    {
                        InstructorName = name,
                        InstructorSurname = surname,
                        FatherNameOfInstructor = fatherName,
                        Email = email,
                        Password = password,
                        BranchId = branchId,
                        DateOfBirth = date,
                    };

                    if (CheckingInstructorDoesntExists(instructor))
                    {
                        context.Instructors.Add(instructor);
                        context.SaveChanges();

                        lbl_status.Text = "Instructor was added successfully.";

                        ClearFields();
                    }
                    else
                    {
                        lbl_status.Text = "This instructor already exists.";
                    }

                }
                else
                {
                    lbl_status.Text = "Passwords don't match.";
                }
            }
            else
            {
                lbl_status.Text = "Please fill all required fields.";
            }
        }
    }
}