using System.Net.Mail;
using System.Net;

namespace ONLINE_POST.Models.functionality
{
    public class verifyemail
    {
        public verifyemail(string email,string body, string msg)
        {
            SmtpClient mail = new SmtpClient();
            mail.Host = "smtp.gmail.com";
            mail.Port = 587;
            mail.EnableSsl = true;
            mail.Credentials = new NetworkCredential("usman67483@gmail.com", "twfibgsvijyzisjy");
            MailMessage message = new MailMessage();
            message.From = new MailAddress("usman67483@gmail.com");
            message.To.Add(email);
            message.Subject = msg;
            message.Body = body;
            message.IsBodyHtml = true;
            mail.Send(message);
        }
    }
}
