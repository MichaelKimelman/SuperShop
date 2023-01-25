using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace StefansSuperShop.Pages.ContactUs
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
             
        }

        public void OnPost()
        {

            var name = Request.Form["name"];
            var email = Request.Form["email"];
            var subject = Request.Form["subject"];
            var text = Request.Form["text"];
            ViewData["confirmation"] = $"Thank you for your message.We will contact you in 2-3 working days";

            #if DEBUG
            SendEmailEthereal(name, email, subject, text);
            #endif
            #if RELEASE
            SendEmailMailTrap(name, email, subject, text);
            #endif
        }

        public bool SendEmailMailTrap(string name, string email, string subject, string text)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            mail.From = new MailAddress(email);
            mail.To.Add("info@systementor.se");
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = "<p>" + name + "</p>" + "<p>" + text + "</p>";

            smtpClient.Port = 587;
            smtpClient.Host = "smtp.mailtrap.io";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("fa3efda397f745", "12280a15e0a81a");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(mail);
            return true;
        }

        public bool SendEmailEthereal(string name, string email, string subject, string text)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            mail.From = new MailAddress(email);
            mail.To.Add("info@systementor.se");
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = "<p>" + name + "</p>" + "<p>" + text + "</p>";

            smtpClient.Port = 587;
            smtpClient.Host = "smtp.ethereal.email";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("amely19@ethereal.email", "45rq59Zs88Bv2PRRrb");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(mail);
            return true;
        }
    }
}
