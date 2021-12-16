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

            List<Branch> branches = new List<Branch>()
            {
                new Branch{BranchName = "Accounting and Audit"},
                new Branch{BranchName = "Architecture and Design"},
                new Branch{BranchName = "Chemistry"},
                new Branch{BranchName = "Computer and Information Technologies"},
                new Branch{BranchName = "Foreign languages"},
                new Branch{BranchName = "Mechanical Engineering"},
            };

            foreach (Branch branch in branches)
            {
                context.Branches.Add(branch);
            }

            List<Instructor> instructors = new List<Instructor>()
            {
                new Instructor{InstructorName = "InstructorName", InstructorSurname = "InstructorSurname", FatherNameOfInstructor = "FatherNameOfInstructor", Email = "instructor@gmail.com", Password = "instructor123", BranchId = 1},
                new Instructor{InstructorName = "Jolie", InstructorSurname = "Holder", FatherNameOfInstructor = "Josh", Email = "jolieholder@gmail.com", Password = "jolie123", BranchId = 2},
                new Instructor{InstructorName = "Troy", InstructorSurname = "Ward", FatherNameOfInstructor = "Markus", Email = "troyward@gmail.com", Password = "troy123", BranchId = 3},
                new Instructor{InstructorName = "Branson", InstructorSurname = "Cochran", FatherNameOfInstructor = "Manuel", Email = "bransoncochran@gmail.com", Password = "branson123", BranchId = 4},
                new Instructor{InstructorName = "Erica", InstructorSurname = "Cannon", FatherNameOfInstructor = "Desmond", Email = "ericacannon@gmail.com", Password = "erica123", BranchId = 5},
            };

            foreach (Instructor instructor in instructors)
            {
                context.Instructors.Add(instructor);
            }


            List<Course> courses = new List<Course>()
            {
                new Course{CourseName = "Fundamentals of computer engineering"},
                new Course{CourseName = "Linear Algebra and Calculus"},
                new Course{CourseName = "Data Structures and Algorithms"},
                new Course{CourseName = "Computer Architecture"},
                new Course{CourseName = "Probabilty theory and mathematical statistics"},
                new Course{CourseName = "Basics of Electronics"},
                new Course{CourseName = "Information Security"},
                new Course{CourseName = "Web Design"},
                new Course{CourseName = "Data Mining and Storing"},
                new Course{CourseName = "Machine Learning"},
                new Course{CourseName = "Modern Programming Languages I"},
                new Course{CourseName = "Graphic design"},
            };

            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }

            List<Profesion> profesions = new List<Profesion>()
            {
                new Profesion{ProfesionName = "Accounting"},
                new Profesion{ProfesionName = "Business Administration"},
                new Profesion{ProfesionName = "Architecture"},
                new Profesion{ProfesionName = "Design"},
                new Profesion{ProfesionName = "Chemistry Education"},
                new Profesion{ProfesionName = "Chemical Engineering"},
                new Profesion{ProfesionName = "Information Technologies"},
                new Profesion{ProfesionName = "Cybersecurity"},
                new Profesion{ProfesionName = "Mechanical Engineering"},
            };

            foreach (Profesion profesion in profesions)
            {
                context.Profesions.Add(profesion);
            }

            List<Student> students = new List<Student>()
            {
                new Student{ StudentName = "StudentName", StudentSurname = "StudentSurname", FatherNameOfStudent = "FatherNameOfStudent", Email = "student@gmail.com", Password = "student", ProfesionId = 1,},
                new Student{ StudentName = "Sahil", StudentSurname = "Hashimli", FatherNameOfStudent = "Qanbar", Email = "hashimlisahil@gmail.com", Password = "sahil123", ProfesionId = 1,},
                new Student{ StudentName = "Jesse", StudentSurname = "Hodge", FatherNameOfStudent = "Roger", Email = "jessehodge@gmail.com", Password = "jesse123", ProfesionId = 2,},
                new Student{ StudentName = "Skye", StudentSurname = "Riley", FatherNameOfStudent = "Damion", Email = "skyeriley@gmail.com", Password = "skye123", ProfesionId = 2,},
                new Student{ StudentName = "Matias", StudentSurname = "Robinson", FatherNameOfStudent = "Konner", Email = "matiasrobinson@gmail.com", Password = "matias123", ProfesionId = 3,},
                new Student{ StudentName = "Matteo", StudentSurname = "Gray", FatherNameOfStudent = "Elliott", Email = "matteogray@gmail.com", Password = "matteo123", ProfesionId = 4,},
                new Student{ StudentName = "Olivia", StudentSurname = "Stanton", FatherNameOfStudent = "Curtis", Email = "oliviastanton@gmail.com", Password = "olivia123", ProfesionId = 3,},
                new Student{ StudentName = "Sara", StudentSurname = "Chapman", FatherNameOfStudent = "Leonard", Email = "sarachapman@gmail.com", Password = "sara123", ProfesionId = 5,},
            };

            foreach (Student student in students)
            {
                context.Students.Add(student);
            }

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

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}