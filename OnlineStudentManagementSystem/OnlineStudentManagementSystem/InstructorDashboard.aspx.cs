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
            var students = context.Students;
            var studentsList = students.ToList();
            gv_Students.DataSource = studentsList;
            gv_Students.DataBind();
        }

    }
}