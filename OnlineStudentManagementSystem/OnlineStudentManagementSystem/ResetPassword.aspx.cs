using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStudentManagementSystem
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_code.Visible = false;
            btn_submit.Visible = false;
            btn_send.Visible = true;
        }

        public readonly Context context = new Context();
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        private bool writeCodeToDatabase(String code)
        {
            try
            {
                ResetCode resetCode = new ResetCode
                {
                    Email = tb_email.Text.Trim(),
                    Code = code,
                    Deadline = DateTime.Now,
                };

                context.ResetCodes.Add(resetCode);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        Random r = new Random();
        private int generateCode()
        {
            return r.Next(10000, 99999);
        }
        private bool SendMail()
        {
            try
            {
                string to = tb_email.Text;
                string email = to;
                string from = "sahilhashimli2@gmail.com";
                string pass = "sahil1234@";
                string code = generateCode().ToString();

                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(to));
                mm.From = new MailAddress(from, "Student Management");
                mm.Subject = "Password Recovery";
                mm.IsBodyHtml = true;
                mm.Body = "Your account recovery code: <b>" + code + "</b>";

                NetworkCredential nc = new NetworkCredential();
                nc.UserName = from;
                nc.Password = pass;

                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Port = 587;
                sc.UseDefaultCredentials = false;
                sc.Credentials = nc;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Send(mm);
                writeCodeToDatabase(code);

                return true;
            }
            catch { return false; }

        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            ClearOldCode();
            Student studentCheck = context.Students.FirstOrDefault(s => s.Email == tb_email.Text.Trim());
            if(studentCheck != null)
            {
                SendMail();
                lbl_status.Text = "Please check message that we sent to your email. Write reset code the following field to reset password.";
                tb_code.Visible = true;
                btn_send.Visible = false;
                btn_submit.Visible = true;
            }
            else
            {
                lbl_status.Text = "User couldn't find";
            }
            
        }

        private void ClearOldCode()
        {
            //var oldCodes = from code in context.ResetCodes select new { code.Email };
            //var oldCodesList = oldCodes.ToList();



            var oldCodeForDelete = (from o in context.ResetCodes
                                          where o.Email == tb_email.Text.Trim()
                                          select o);
            if (oldCodeForDelete != null)
            {
                foreach (var oldCode in oldCodeForDelete)
                {
                    if (oldCode.Email == tb_email.Text.Trim())
                    {
                        context.ResetCodes.Remove(oldCode);                        
                    }
                }
            }
            context.SaveChanges();
        }

        public string CheckAdmin(Admin a)
        {
            var registeredAdmin = context.Admins.FirstOrDefault(rm => rm.Email.Equals(a.Email));

            if (registeredAdmin != null)
            {
                return "admin";
            }
            else
            {
                return "notfound";
            }
        }
        public string CheckStudent(Student s)
        {
            var registeredStudent = context.Students.FirstOrDefault(i => i.Email.Equals(s.Email));

            if (registeredStudent != null)
            {
                return "student";
            }
            else
            {
                return "notfound";
            }
        }
        public string CheckInstructor(Instructor ins)
        {
            var registeredInstructor = context.Instructors.FirstOrDefault(i => i.Email.Equals(ins.Email));

            if (registeredInstructor != null)
            {
                return "instructor";
            }
            else
            {
                return "notfound";
            }
        }
        private void CodeCheck()
        {
            ResetCode resetCode = context.ResetCodes.FirstOrDefault(rc => rc.Email == tb_email.Text.Trim());
            if (resetCode != null)
            {
                DateTime now = DateTime.Now;

                TimeSpan ts = now.Subtract(resetCode.Deadline);

                if (ts.TotalMinutes < 3)
                {
                    if (tb_code.Text.Trim() == resetCode.Code)
                    {
                        Admin admin = new Admin
                        {
                            Email = tb_email.Text,
                        };

                        Student loginStudent = new Student()
                        {
                            Email = tb_email.Text,
                        };

                        Instructor loginInstructor = new Instructor()
                        {
                            Email = tb_email.Text,
                        };

                        if (CheckAdmin(admin) == "admin")
                        {
                            int id = context.Admins.FirstOrDefault(a => a.Email == tb_email.Text).AdminID;
                            Session["user"] = id;
                        }
                        else if (CheckStudent(loginStudent) == "student")
                        {
                            int id = context.Students.FirstOrDefault(s => s.Email == tb_email.Text).StudentID;
                            Session["user"] = id;
                        }
                        else if (CheckInstructor(loginInstructor) == "instructor")
                        {
                            int id = context.Instructors.FirstOrDefault(i => i.Email == tb_email.Text).InstructorID;
                            Session["user"] = id;
                        }

                        Response.Redirect("NewPassword.aspx");
                    }
                    else
                    {
                        lbl_status.Text = "Code is invalid. Please try again.";
                    }
                }
                else
                {
                    lbl_status.Text = "Code is invalid. Please try send message again.";
                }
            }
            else
            {
                lbl_status.Text = "Something gets wrong :(";
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {          
            CodeCheck();
        }
    }
}