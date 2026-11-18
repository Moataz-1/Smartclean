using MailKit;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Smartclean.core.DTO;
using Smartclean.core.Services;

namespace Smartclean.infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(EmailDTO emailDTO)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Smartclean",_configuration["EmailSettings:From"]));
            message.Subject = emailDTO.Subject;
            message.To.Add(new MailboxAddress(emailDTO.To, emailDTO.To));
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailDTO.Content
            };
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync(
                        _configuration["EmailSettings:smtp"], 
                        int.Parse(_configuration["EmailSettings:Port"]), true);
                    await smtp.AuthenticateAsync(
                        _configuration["EmailSettings:Name"],
                        _configuration["EmailSettings:Password"]);

                    await smtp.SendAsync(message);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    smtp.Disconnect(true);
                    smtp.Dispose();
                }
            }
            
        }
    }
}
