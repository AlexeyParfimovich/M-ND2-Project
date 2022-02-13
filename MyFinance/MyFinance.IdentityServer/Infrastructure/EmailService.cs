using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MyFinance.IdentityServer.Infrastructure
{
    public class EmailService: IEmailService
    {
        private readonly IConfigurationSection _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration.GetSection("EmailServerSettings");
        }

        public async Task SendTextAsync(string address, string subject, string message)
        {
            var email = CreateEmail(address, subject, message, TextFormat.Text);
            await SendEmail(email);
        }

        public async Task SendHtmlAsync(string address, string subject, string message)
        {
            var email = CreateEmail(address, subject, message, TextFormat.Html);
            await SendEmail(email);
        }

        private async Task SendEmail(MimeMessage email)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_config["SmtpAddress"], int.Parse(_config["SmtpPort"]), bool.Parse(_config["SmtpSSO"]));
                await client.AuthenticateAsync(_config["FromAddress"], _config["Password"]);

                var result = await client.SendAsync(email);
#if DEBUG
                Console.WriteLine($"Email message sent: {result}");
#endif
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                await client.DisconnectAsync(true);
#if DEBUG
                Console.WriteLine($"Email sending error: {ex.Message}");
#endif
            }
        }

        private MimeMessage CreateEmail(string address, string subject, string message, TextFormat format)
        {
            var email = new MimeMessage();

            email.To.Add(new MailboxAddress("", address));
            email.From.Add(new MailboxAddress(_config["FromName"], _config["FromAddress"]));
            email.Subject = subject;
            email.Body = new TextPart(format)
            {
                Text = message
            };

            return email;
        }
    }
}
