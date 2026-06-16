using EmailService.Model;

namespace EmailService.Services
{
    public interface IEmailServices
    {

        bool SendEmailMessageToUser(Email email);
        bool SendEmailOtpToUser(string userEmail);
    }
}
