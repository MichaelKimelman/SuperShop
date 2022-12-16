namespace StefansSuperShop.Services
{
    public interface IEmailSenderService
    {
        void SendEmail(string email, string name, string header, string message);
    }
}
