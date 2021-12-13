using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var instructors = context.Instructors.ToList();
            foreach (var instructor in instructors)
            {
                string insName = instructor.InstructorName;
                string insSurname = instructor.InstructorSurname;
                string insFullname = insName + " " + insSurname;
                var exist = ddl_instructor.Items.FindByValue(insFullname);
                if (exist == null)
                {
                    string fullname = instructor.InstructorName + " " + instructor.InstructorSurname;
                    ddl_instructor.Items.Add(fullname);
                }
            }
        }

        public readonly Context context = new Context();
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }

        public void ClearFields()
        {
            tb_name.Text = "";
            ddl_instructor.SelectedIndex = 0;
        }

        public bool CheckingCourseDoesntExists(Course c)
        {
            var oldCourse = context.Courses.FirstOrDefault(oc => oc.CourseName == c.CourseName);
            if (oldCourse != null)
                return false;
            return true;
        }
        protected void btn_addCourse_Click(object sender, EventArgs e)
        {
            string name = tb_name.Text.Trim();
            string instructorFullName = ddl_instructor.SelectedValue;
            string[] instructorSplitedName = instructorFullName.Split(' ');
            string instructorName = instructorSplitedName[0];
            string instructorSurname = instructorSplitedName[1];

            if (name != "" && instructorName != "")
            {
                int instructorId = context.Instructors.FirstOrDefault(i => i.InstructorName == instructorName && i.InstructorSurname == instructorSurname).InstructorID;
                Course course = new Course()
                {
                    CourseName = name,
                    InstructorId = instructorId,
                };

                if (CheckingCourseDoesntExists(course))
                {
                    context.Courses.Add(course);
                    context.SaveChanges();

                    lbl_status.Text = "Course was added successfully.";

                    ClearFields();
                }
                else
                {
                    lbl_status.Text = "This course already exists.";
                }
            }
            else
            {
                lbl_status.Text = "Please fill all required fields.";
            }
        }
    }
}