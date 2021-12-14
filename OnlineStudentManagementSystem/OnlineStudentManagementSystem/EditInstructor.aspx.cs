using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class EditInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var branches = context.Branches.ToList();
            foreach (var branch in branches)
            {
                var exist = DropDownList_Branch.Items.FindByValue(branch.BranchName);
                if (exist == null)
                {
                    DropDownList_Branch.Items.Add(branch.BranchName);
                }
            }

            if (tb_name.Text == "")
            {
                GetDefaultData();
            }
        }

        public readonly Context context = new Context();

        public bool deleted = false;

        public void GetDefaultData()
        {
            string idString = Session["user"].ToString();

            try
            {
                int id = Int32.Parse(idString);
                Instructor instructor = context.Instructors.FirstOrDefault(i => i.InstructorID == id);

                tb_name.Text = instructor.InstructorName;
                tb_surname.Text = instructor.InstructorSurname;
                tb_fatherName.Text = instructor.FatherNameOfInstructor;
                tb_email.Text = instructor.Email;
                string dateAndclock = Convert.ToString(instructor.DateOfBirth);
                string[] date = dateAndclock.Split(' ');
                tb_currentDate.Text = date[0];
                tb_password.Text = instructor.Password;
                tb_conpassword.Text = instructor.Password;
                Branch branchId = context.Branches.FirstOrDefault(b => b.BranchId == instructor.BranchId);
                DropDownList_Branch.SelectedValue = branchId.BranchName;
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
            string idStringforDelete = Session["user"].ToString();
            int idforDelete = Int32.Parse(idStringforDelete);
            Instructor instructor = context.Instructors.FirstOrDefault(i => i.InstructorID == idforDelete);

            context.Instructors.Remove(instructor);
            context.SaveChanges();
            Response.Redirect("AdminPanel.aspx?status=deletedInstructor");
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string idStringforUpdate = Session["user"].ToString();
            int idforUpdate = Int32.Parse(idStringforUpdate);
            Instructor instructor = context.Instructors.FirstOrDefault(i => i.InstructorID == idforUpdate);

            if (tb_name.Text != "" && tb_surname.Text != "" && tb_fatherName.Text != "" && tb_password.Text != "" && tb_conpassword.Text != "" && tb_email.Text != "")
            {
                instructor.InstructorName = tb_name.Text;
                instructor.InstructorSurname = tb_surname.Text;
                instructor.FatherNameOfInstructor = tb_fatherName.Text;
                instructor.Email = tb_email.Text;

                Branch branch = context.Branches.FirstOrDefault(b => b.BranchName == DropDownList_Branch.SelectedValue);

                instructor.BranchId = branch.BranchId;

                if (tb_date.Text == "")
                {
                    instructor.DateOfBirth = Convert.ToDateTime(tb_currentDate.Text);
                }
                else
                {
                    DateTime date = Convert.ToDateTime(tb_date.Text);
                    instructor.DateOfBirth = date;
                }

                if (tb_password.Text == tb_conpassword.Text)
                {
                    instructor.Password = tb_password.Text;

                    context.SaveChanges();
                    Response.Redirect("AdminPanel.aspx?status=updatedInstructor");
                }
                else
                {
                    lbl_status.Text = "Passwords don't match.";
                }
            }
            else
            {
                lbl_status.Text = "Required fields can not be left blank.";
            }
        }
    }
}