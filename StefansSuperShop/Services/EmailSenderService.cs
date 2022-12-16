using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;


namespace StefansSuperShop.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly MailSettings _settings;
        public EmailSenderService(MailSettings mailSettings)
        {
            _settings = mailSettings;
        }
        public void SendEmail(string email, string name, string header, string message)
        {
            var mail = new MimeMessage();

            mail.From.Add(new MailboxAddress(_settings.DisplayName, _settings.From));
            mail.Sender = new MailboxAddress(_settings.DisplayName, _settings.From);

            mail.To.Add(MailboxAddress.Parse(email));

            var body = new BodyBuilder();
            mail.Subject = header;
            body.HtmlBody = message;
            mail.Body = body.ToMessageBody();

            using var smtp = new SmtpClient();
            
            if (_settings.UseSSL)
            {
                smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect).Wait();
            }
            else if (_settings.UseStartTls)
            {
                smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls).Wait();
            }
            smtp.AuthenticateAsync(_settings.UserName, _settings.Password).Wait();
            smtp.SendAsync(mail).Wait();
            smtp.DisconnectAsync(true).Wait();

        }
    }
}
