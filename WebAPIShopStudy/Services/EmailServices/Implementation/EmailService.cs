using MailKit.Net.Smtp;
using MimeKit;
using WebAPIShopStudy.Models;
using WebAPIShopStudy.Services.EmailServices.Interfaces;

namespace WebAPIShopStudy.Services.EmailServices.Implementation;

public class EmailService : IEmailService {

    public EmailService(IConfiguration configuration) {
        _configuration = configuration;
    }


    private readonly IConfiguration _configuration;

    public async Task SendEmailAsync(MailRequest mailRequest) {
        using var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress(_configuration["EmailSettings:DisplayName"], _configuration["EmailSettings:EmailFrom"]));
        emailMessage.To.Add(new MailboxAddress("", mailRequest.ToEmail));
        emailMessage.Subject = mailRequest.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
            Text = mailRequest.Body
        };

        using (var client = new SmtpClient()) {
            await client.ConnectAsync(_configuration["EmailSettings:Host"], int.Parse(_configuration["EmailSettings:Port"]!), true);
            await client.AuthenticateAsync(_configuration["EmailSettings:EmailFrom"], _configuration["EmailSettings:Password"]);
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }

    }
}