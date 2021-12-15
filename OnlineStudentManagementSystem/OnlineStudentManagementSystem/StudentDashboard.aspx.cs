using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class StudentDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Session["user"].ToString());
            Student student = context.Students.FirstOrDefault(s => s.StudentID == id);
            lbl_fullName.Text = student.StudentName + " " + student.StudentSurname;

            Profesion profesion = context.Profesions.FirstOrDefault(p => p.ProfesionId == student.ProfesionId);
            lbl_profesion.Text = profesion.ProfesionName;
        }
        public readonly Context context = new Context();

        public void ClearOtherTables(string table)
        {
            switch (table)
            {
                case "grade":
                    gv_Courses.Visible = false;
                    gv_Grades.Visible = true;
                    return;
                case "course":
                    gv_Grades.Visible = true;
                    gv_Courses.Visible = false;
                    return;
            }
        }
        protected void btn_Grades_Click(object sender, EventArgs e)
        {
            //ClearOtherTables("grade");
            int id = Int32.Parse(Session["user"].ToString());
            var gradesList = context.Grades.Where(g => g.StudentID == id).ToList();
            if(gradesList != null)
            {
                gv_Grades.DataSource = gradesList;
                gv_Grades.DataBind();
            }
            
        }

        protected void btn_Course_Click(object sender, EventArgs e)
        {
            //ClearOtherTables("course");
            var courses = context.Courses;
            var courseList = courses.ToList();
            gv_Courses.DataSource = courseList;
            gv_Courses.DataBind();
      
        }

        protected void gv_Courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Int32.Parse(Session["user"].ToString());
            Student student = context.Students.FirstOrDefault(s => s.StudentID == id);

            int courseId = Int32.Parse(gv_Courses.SelectedRow.Cells[1].Text);

            Course course = context.Courses.FirstOrDefault(c => c.CourseID == courseId);

            StudentCourse studentCourse = new StudentCourse
            {
                StudentId = student.StudentID,
                CourseId = course.CourseID,
            };
            context.StudentCourses.Add(studentCourse);

            context.SaveChanges();
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}