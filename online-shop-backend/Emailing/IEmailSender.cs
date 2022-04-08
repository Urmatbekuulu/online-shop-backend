using System.Threading.Tasks;

namespace online_shop_backend.Emailing
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string body, string from = null);
    }
}