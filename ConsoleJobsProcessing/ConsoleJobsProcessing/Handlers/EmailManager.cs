using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJobsProcessing.Handlers
{
    public class EmailManager
    {
        const string fromEmail = "mariusmorar14@gmail.com";
        const string toEmail = "mariusmorar14@gmail.com";
        const string password = "Laurelhardy1";

        public void SendEmail(string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(fromEmail);
                message.To.Add(new MailAddress(toEmail));
                message.Subject = subject;
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; 
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
