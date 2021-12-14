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
            lbl_Score.Visible = false;
            tb_Score.Visible = false;
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

        protected void btn_GetStudentsFromCourse_Click(object sender, EventArgs e)
        {
            //string courseName = ddl_Course.SelectedValue;

            //var students = from student in context.Students select new { student.Course.CourseName == courseName };
            //var studentList = students.ToList();
            //gv_Students.DataSource = studentList;
            //gv_Students.DataBind();
        }

        protected void btn_AddGrade_Click(object sender, EventArgs e)
        {
            var students = from student in context.Students select new { student.StudentID, student.StudentName, student.StudentSurname, student.FatherNameOfStudent, student.Email, student.ProfesionId };
            var studentsList = students.ToList();
            gv_Grades.DataSource = studentsList;
            gv_Grades.DataBind();
            lbl_Score.Visible = true;
            tb_Score.Visible = true;

        }

        protected void gv_Grades_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int score = Int32.Parse(tb_Score.Text);
            int studentId = Int32.Parse(gv_Grades.SelectedRow.Cells[1].Text);

            Grade grade = new Grade
            {
                StudentID = studentId,
                CourseID = 1,
                GradeScore = score,
            };

            context.Grades.Add(grade);
            context.SaveChanges();

        }
    }
}