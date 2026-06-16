using EmailService.Model;

namespace EmailService.Repository
{
    public interface IEmailRepository
    {
        bool SendMail(string email);
        bool SendMailMessage(Email email);
    }
}
