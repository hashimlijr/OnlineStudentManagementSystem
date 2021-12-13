using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var profesions = context.Profesions.ToList();
            foreach(var profesion in profesions){
                DropDownList_Profesion.Items.Add(profesion.ProfesionName);
            }
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
            DropDownList_Profesion.SelectedIndex = 0;
            tb_date.Text = "";
        }

        public bool CheckingStudentDoesntExists(Student s)
        {
            var oldUser = context.Students.FirstOrDefault(ou => ou.Email == s.Email);
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
            string profesionName = DropDownList_Profesion.SelectedValue;
            string dateString = tb_date.Text.Trim();            
                     
            int profesionId = context.Profesions.FirstOrDefault(i => i.ProfesionName == profesionName).ProfesionId;

            if(name != "" && surname != "" && email != "" && password != "" && conpassword != "" && fatherName != "" && dateString != "")
            {
                if(password == conpassword)
                {
                    DateTime date = Convert.ToDateTime(dateString);

                    Student student = new Student()
                    {
                        StudentName = name,
                        StudentSurname = surname,
                        FatherNameOfStudent = fatherName,
                        Email = email,
                        Password = password,
                        ProfesionId = profesionId,
                        DateOfBirth = date,
                    };

                    if (CheckingStudentDoesntExists(student))
                    {
                        context.Students.Add(student);
                        context.SaveChanges();

                        lbl_status.Text = "Student was added successfully.";

                        ClearFields();
                    }
                    else
                    {
                        lbl_status.Text = "This student already exists.";
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

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }
    }
}