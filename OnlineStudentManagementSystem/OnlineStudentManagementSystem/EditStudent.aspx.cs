using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class EditStudent : System.Web.UI.Page
    {
        public bool updated = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            var profesions = context.Profesions.ToList();
            foreach (var profesion in profesions)
            {
                DropDownList_Profesion.Items.Add(profesion.ProfesionName);
            }

            if(tb_name.Text == "")
            {
                GetDefaultData();
            }
                             
        }

        public readonly Context context = new Context();

        public bool deleted = false;
        
        public void GetDefaultData()
        {
            string idString = Request.QueryString["id"];

            try
            {
                int id = Int32.Parse(idString);
                Student student = context.Students.FirstOrDefault(s => s.StudentID == id);

                tb_name.Text = student.StudentName;
                tb_surname.Text = student.StudentSurname;
                tb_fatherName.Text = student.FatherNameOfStudent;
                tb_email.Text = student.Email;
                string dateAndclock = Convert.ToString(student.DateOfBirth);
                string[] date = dateAndclock.Split(' ');
                tb_currentDate.Text = date[0];
                tb_password.Text = student.Password;
                tb_conpassword.Text = student.Password;
                Profesion profesionId = context.Profesions.FirstOrDefault(p => p.ProfesionId == student.ProfesionId);
                DropDownList_Profesion.SelectedValue = profesionId.ProfesionName;
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
            string idStringforUpdate = Request.QueryString["id"];
            int idforUpdate = Int32.Parse(idStringforUpdate);
            Student student = context.Students.FirstOrDefault(s => s.StudentID == idforUpdate);

            if(tb_name.Text != "" && tb_surname.Text != "" && tb_fatherName.Text != "" && tb_password.Text != "" && tb_conpassword.Text != "" && tb_email.Text != "")
            {
                student.StudentName = tb_name.Text;
                student.StudentSurname = tb_surname.Text;
                student.FatherNameOfStudent = tb_fatherName.Text;
                student.Email = tb_email.Text;

                Profesion profesion = context.Profesions.FirstOrDefault(p => p.ProfesionName == DropDownList_Profesion.SelectedValue);

                student.ProfesionId = profesion.ProfesionId;

                if(tb_date.Text == "")
                {
                    student.DateOfBirth = Convert.ToDateTime(tb_currentDate.Text);
                }
                else
                {
                    DateTime date = Convert.ToDateTime(tb_date.Text);
                    student.DateOfBirth = date;
                }
                
                if (tb_password.Text == tb_conpassword.Text)
                {
                    student.Password = tb_password.Text;

                    context.SaveChanges();
                    Response.Redirect("AdminPanel.aspx?status=updatedStudent");
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

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            string idStringforDelete = Request.QueryString["id"];
            int idforDelete = Int32.Parse(idStringforDelete);
            Student student = context.Students.FirstOrDefault(s => s.StudentID == idforDelete);
            context.Students.Remove(student);
            context.SaveChanges();
            Response.Redirect("AdminPanel.aspx?status=deletedStudent");
        }
    }
}