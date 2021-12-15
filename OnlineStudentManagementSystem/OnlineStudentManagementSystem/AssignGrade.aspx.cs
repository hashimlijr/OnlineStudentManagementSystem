using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class AssignGrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int studentId = Int32.Parse(Request.QueryString["studentId"]);

            Student student = context.Students.FirstOrDefault(s => s.StudentID == studentId);
            lbl_student_fullName.Text = student.StudentName + " " + student.StudentSurname;
            var courses = context.Courses.ToList();
            foreach(var course in courses)
            {
                if(ddl_Courses.SelectedValue != course.CourseName)
                {
                    ddl_Courses.Items.Add(course.CourseName);
                }
            }
        }

        public readonly Context context = new Context();
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorDashboard.aspx");
        }

        protected void btn_assign_Click(object sender, EventArgs e)
        {
            try
            {
                Grade grade = new Grade();

                int score = Int32.Parse(tb_score.Text.Trim());
                string courseName = ddl_Courses.SelectedValue;
                int studentId = Int32.Parse(Request.QueryString["studentId"]);

                int courseId = context.Courses.FirstOrDefault(c => c.CourseName == courseName).CourseID;

                grade.CourseID = courseId;
                grade.StudentID = studentId;
                grade.GradeScore = score;

                context.Grades.Add(grade);

                context.SaveChanges();

                lbl_status.Text = "Mark was added successfully";
            }
            catch
            {
                lbl_status.Text = "Something gets wrong :(";
            }
        }
    }
}