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
            var courses = context.Courses.ToList();

            foreach(var course in courses)
            {
                ddl_Course.Items.Add(course.CourseName);
            }
        }
        public Context context = new Context();
        protected void btn_GetAllStudents_Click(object sender, EventArgs e)
        {
            //var students = context.Students;
            var students = from student in context.Students select new { student.StudentID, student.StudentName, student.StudentSurname, student.FatherNameOfStudent, student.Email, student.ProfesionId};
            var studentsList = students.ToList();
            gv_Students.DataSource = studentsList;
            gv_Students.DataBind();
        }

        protected void gv_Students_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idString = gv_Students.SelectedRow.Cells[1].Text;
            string name = gv_Students.SelectedRow.Cells[2].Text;
            string surname = gv_Students.SelectedRow.Cells[3].Text;
            lbl_CurrentStudent.Text = "Selected student: " + idString + " " + name + " " + surname;

            try
            {
                int id = Int32.Parse(idString);
            }
            catch
            {
                lbl_CurrentStudent.Text = "Selected student: Something get wrong :(";
            }
            
        }
    }
}