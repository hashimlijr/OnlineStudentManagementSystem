using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class InstructorDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                    
        }
        public Context context = new Context();

        public void ClearOtherTables(string table)
        {
            switch (table)
            {
                case "grade": 
                    gv_Students.Visible = false;
                    gv_Grades.Visible = true;
                    return;
                case "student":
                    gv_Students.Visible = true;
                    gv_Grades.Visible = false;
                    return;
            }            
        }
        protected void btn_GetAllStudents_Click(object sender, EventArgs e)
        {
            //var students = context.Students;
            var students = from student in context.Students select new { student.StudentID, student.StudentName, student.StudentSurname, student.FatherNameOfStudent, student.Email, student.ProfesionId};
            var studentsList = students.ToList();
            gv_Students.DataSource = studentsList;
            gv_Students.DataBind();
        }   

        protected void btn_AddGrade_Click(object sender, EventArgs e)
        {
            //ClearOtherTables("grade");
            var students = from student in context.Students select new { student.StudentID, student.StudentName, student.StudentSurname, student.FatherNameOfStudent, student.Email, student.ProfesionId };
            var studentsList = students.ToList();
            gv_Grades.DataSource = studentsList;
            gv_Grades.DataBind();
        }

        protected void gv_Grades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studentId = gv_Grades.SelectedRow.Cells[1].Text;

            Response.Redirect("AssignGrade.aspx?studentId=" + studentId);
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}