using MailKitDemo.Models;

namespace MailKitDemo.Services
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailData mailData, CancellationToken ct);
    }
}
