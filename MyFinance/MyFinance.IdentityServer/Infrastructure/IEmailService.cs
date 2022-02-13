using System.Threading.Tasks;

namespace MyFinance.IdentityServer.Infrastructure
{
    public interface IEmailService
    {
        Task SendTextAsync(string address, string subject, string message);
        Task SendHtmlAsync(string address, string subject, string message);
    }
}
