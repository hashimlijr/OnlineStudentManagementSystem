using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Status.Text = "";
            string status = Request.QueryString["status"];

            switch (status)
            {
                case "deletedStudent": 
                    lbl_Status.Text = "Student deleted succesfully."; 
                    break;
                case "updatedStudent":
                    lbl_Status.Text = "Student has been updated succesfully.";
                    break;
                case "deletedInstructor":
                    lbl_Status.Text = "Instructor deleted succesfully.";
                    break;
                case "updatedInstructor":
                    lbl_Status.Text = "Instructor has been updated succesfully.";
                    break;
            }
        }
        public Context context = new Context();
        protected void btn_CreateDB_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin
            {
                AdminName = "Sahil",
                AdminSurname = "Hashimli",
                Email = "admin@gmail.com",
                Password = "admin123",
            };
            context.Admins.Add(admin);

            Branch branch = new Branch()
            {
                BranchName = "BranchName",
            };
            context.Branches.Add(branch);

            Instructor instructor = new Instructor()
            {
                InstructorName = "InstructorName",
                InstructorSurname = "InstructorSurname",
                FatherNameOfInstructor = "FatherNameOfInstructor",
                Email = "instructor@gmail.com",
                Password = "instructor123",
                BranchId = 1,
            };
            context.Instructors.Add(instructor);

            Course course = new Course()
            {
                CourseName = "CourseName",
            };
            context.Courses.Add(course);

            Profesion profesion = new Profesion()
            {
                ProfesionName = "ProfesionName",
            };
            context.Profesions.Add(profesion);

            Student studenttest = new Student()
            {
                StudentName = "StudentName",
                StudentSurname = "StudentSurname",
                FatherNameOfStudent = "FatherNameOfStudent",
                Email = "student@gmail.com",
                Password = "student",
                ProfesionId = 1,
            };
            context.Students.Add(studenttest);





            //grade.CourseID = 2;
            //grade.GradeScore = 91;
            //context.Grades.Add(grade);

            //grade.StudentID = 2;
            //grade.CourseID = 2;
            //grade.GradeScore = 100;

            //Student student1 = context.Students.FirstOrDefault(s => s.StudentID == 1);
            //Course course1 = context.Courses.FirstOrDefault(c => c.CourseID == 1);
            //Grade grade1 = new Grade()
            //{
            //    StudentID = student1.StudentID,
            //    CourseID = course1.CourseID,
            //    GradeScore = 98,
            //};

            //context.Grades.Add(grade1);
            //Grade grade2 = new Grade()
            //{

            //    GradeScore = 75,
            //}; 

            //Grade grade3 = new Grade()
            //{
            //    GradeScore = 100,
            //};
            //List<Grade> grades = new List
            //{
            //    new Grade
            //    {
            //        GradeScore = 98,
            //    }
            //};

            //student1.Grades = new List<Grade>();
            //student1.Grades.Add(grade1);
            //student1.Grades.Add(grade2);
            //student1.Grades.Add(grade3);

            context.SaveChanges();
        }

        protected void btn_AddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btn_AddInstructor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInstructor.aspx");
        }

        protected void btn_AddCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }

        protected void btn_AddBranch_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBranch.aspx");
        }

        protected void btn_AddProfesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProfesion.aspx");
        }

        protected void btn_EditStudent_Click(object sender, EventArgs e)
        {
            var students = from student in context.Students select new { student.StudentID, student.StudentName, student.StudentSurname, student.FatherNameOfStudent, student.Email, student.DateOfBirth , student.ProfesionId };
            var studentsList = students.ToList();
            gv_Students.DataSource = studentsList;
            gv_Students.DataBind();
        }

        protected void gv_Students_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idString = gv_Students.SelectedRow.Cells[1].Text;

            try
            {
                Session["user"] = idString;
                Response.Redirect("EditStudent.aspx?id=" + idString);
            }
            catch
            {
                lbl_Status.Text = "Selected student: Something get wrong :(";
            }
        }

        protected void btn_EditInstructor_Click(object sender, EventArgs e)
        {
            var instructors = from instructor in context.Instructors select new { instructor.InstructorID, instructor.InstructorName, instructor.InstructorSurname, instructor.FatherNameOfInstructor, instructor.Email, instructor.DateOfBirth, instructor.BranchId };
            var instructorList = instructors.ToList();
            gv_Instructor.DataSource = instructorList;
            gv_Instructor.DataBind();
        }

        protected void gv_Instructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idString = gv_Instructor.SelectedRow.Cells[1].Text;

            try
            {
                Session["user"] = idString;
                Response.Redirect("EditInstructor.aspx?id=" + idString);
            }
            catch
            {
                lbl_Status.Text = "Selected student: Something get wrong :(";
            }
        }

        protected void btn_EditCourse_Click(object sender, EventArgs e)
        {
            var courses = from course in context.Courses select new { course.CourseID, course.CourseName, course.InstructorId };
            var courseList = courses.ToList();
            gv_Courses.DataSource = courseList;
            gv_Courses.DataBind();
        }

        protected void btn_EditBranch_Click(object sender, EventArgs e)
        {
            var branches = from branch in context.Branches select new { branch.BranchId, branch.BranchName };
            var branchList = branches.ToList();
            gv_Branch.DataSource = branchList;
            gv_Branch.DataBind();
        }

        protected void btn_EditProfesion_Click(object sender, EventArgs e)
        {
            var profesions = from profesion in context.Profesions select new { profesion.ProfesionId, profesion.ProfesionName };
            var profesionList = profesions.ToList();
            gv_Profesion.DataSource = profesionList;
            gv_Profesion.DataBind();
        }

        protected void gv_Courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idString = gv_Courses.SelectedRow.Cells[1].Text;

            try
            {
                Session["user"] = idString;
                Response.Redirect("EditCourse.aspx?id=" + idString);
            }
            catch
            {
                lbl_Status.Text = "Selected course: Something get wrong :(";
            }
        }

        protected void gv_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idString = gv_Branch.SelectedRow.Cells[1].Text;

            try
            {
                Session["user"] = idString;
                Response.Redirect("EditBranch.aspx?id=" + idString);
            }
            catch
            {
                lbl_Status.Text = "Selected branch: Something get wrong :(";
            }
        }

        protected void gv_Profesion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idString = gv_Profesion.SelectedRow.Cells[1].Text;

            try
            {
                Session["user"] = idString;
                Response.Redirect("EditProfesion.aspx?id=" + idString);
            }
            catch
            {
                lbl_Status.Text = "Selected profesion: Something get wrong :(";
            }
        }
    }
}