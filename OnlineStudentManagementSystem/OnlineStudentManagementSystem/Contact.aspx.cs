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
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Status.Visible = false;
        }

        public void ClearFields()
        {
            tb_data.Text = String.Empty;
            tb_Email.Text = String.Empty;
            tb_Name.Text = String.Empty;
        }
        private bool SendMail(string clientName, string clientEmail, string data)
        {
            try
            {
                string to = "hashimlisahil@gmail.com";
                string from = "sahilhashimli2@gmail.com";
                string password = "sahil1234@";

                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(to));
                mm.From = new MailAddress(from, "Student Management");
                mm.Subject = "Feedbacks or questions";
                mm.IsBodyHtml = true;
                mm.Body = "Client name is <b>" + clientName 
                    + "</b> <br> Client email address is <b>" + clientEmail 
                    + "</b> <br> This is what client send: <br>" + data + "<br>"
                    + "Date: " + DateTime.Now;

                NetworkCredential nc = new NetworkCredential();
                nc.UserName = from;
                nc.Password = password;

                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Port = 587;
                sc.UseDefaultCredentials = false;
                sc.Credentials = nc;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Send(mm);

                return true;
            }
            catch { return false; }

        }
        protected void btn_Send_Click(object sender, EventArgs e)
        {
            string name = tb_Name.Text.Trim();
            string email = tb_Email.Text.Trim();
            string data = tb_data.Text.Trim();

            lbl_Status.Visible = true;
            if (tb_Name.Text != String.Empty && tb_Email.Text != String.Empty)
            {                
                if (SendMail(name, email, data))
                {
                    lbl_Status.Text = "Message sent successfully. Thanks for feedbacks :)";
                    ClearFields();
                }
                else
                {
                    lbl_Status.Text = "Message couldn't sent. Please try again.";
                }
            }
            else
            {
                lbl_Status.Text = "Please fill all required fields.";
            }
            

        }
    }
}