using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class EditCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var instructors = context.Instructors.ToList();
            foreach (var instructor in instructors)
            {
                string fullName = instructor.InstructorName + " " + instructor.InstructorSurname;
                var exist = ddl_instructor.Items.FindByValue(fullName);
                if (exist == null)
                {
                    ddl_instructor.Items.Add(fullName);
                }
            }

            if (tb_name.Text == "")
            {
                GetDefaultData();
            }
        }

        public readonly Context context = new Context();

        public void GetDefaultData()
        {
            string idString = Request.QueryString["id"];

            

            try
            {
                int id = Int32.Parse(idString);
                Course course = context.Courses.FirstOrDefault(c => c.CourseID == id);
                Instructor instructor = context.Instructors.FirstOrDefault(i => i.InstructorID == course.InstructorId);

                tb_name.Text = course.CourseName;
                string fullNameOfInstructor = instructor.InstructorName + " " + instructor.InstructorSurname;
                ddl_instructor.SelectedValue = fullNameOfInstructor;

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
            string idStringforDelete = Request.QueryString["id"];
            int idforDelete = Int32.Parse(idStringforDelete);
            Course course = context.Courses.FirstOrDefault(c => c.CourseID == idforDelete);

            context.Courses.Remove(course);
            context.SaveChanges();
            Response.Redirect("AdminPanel.aspx?status=deletedCourse");
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string idStringforUpdate = Request.QueryString["id"];
            int idforUpdate = Int32.Parse(idStringforUpdate);
            Course course = context.Courses.FirstOrDefault(c => c.CourseID == idforUpdate);

            string fullName = ddl_instructor.SelectedValue;
            string[] splitedName = fullName.Split(' ');
            Instructor instructor = context.Instructors.FirstOrDefault(i => i.InstructorName == splitedName[0] && i.InstructorSurname == splitedName[1]);

            if (tb_name.Text != "")
            {
                course.CourseName = tb_name.Text;
                course.InstructorId = instructor.InstructorID;
                context.SaveChanges();
                Response.Redirect("AdminPanel.aspx?status=updatedCourse");
            }
            else
            {
                lbl_status.Text = "Required fields can not be left blank.";
            }
        }
    }
}