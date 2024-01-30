using WebAPIShopStudy.Models;

namespace WebAPIShopStudy.Services.EmailServices.Interfaces;

public interface IEmailService {
    public Task SendEmailAsync(MailRequest mailRequest);
}
