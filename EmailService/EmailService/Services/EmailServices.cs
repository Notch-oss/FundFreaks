using EmailService.Exception;
using EmailService.Model;
using EmailService.Repository;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService.Services
{
    public class EmailServices : IEmailServices
    {

        private readonly IEmailRepository _emailRepository;
        public EmailServices(IEmailRepository emailRepository)
        {

            _emailRepository = emailRepository;
        }

        public bool SendEmailMessageToUser(Email email)
        {
            bool emailStatus = _emailRepository.SendMailMessage(email);
            if (emailStatus)
            {
                return true;
            }
            else
            {
                throw new EmailNotSentExceptiom("Email message Not Sent ");
            }
        }

        public bool SendEmailOtpToUser(string email)
        {
            bool _email = _emailRepository.SendMail(email);
            if (_email)
            {
                return true;
            }
            else
            {
                throw new EmailNotSentExceptiom("Email on OTP To {userEmail} Not Sent ");
            }
        }
    }
}
