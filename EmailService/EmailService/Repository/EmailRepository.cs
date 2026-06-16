using EmailService.Model;
using MailKit.Net.Smtp;
using MimeKit;


namespace EmailService.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;
        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool SendMail(string email)
        {
            var emailmessage = new MimeMessage();
            Random rnd = new Random();
            string rndOTP = (rnd.Next(100000, 999999)).ToString();
            emailmessage.From.Add(MailboxAddress.Parse("fundfreaks@gmail.com"));
            emailmessage.To.Add(MailboxAddress.Parse(email));
            emailmessage.Subject = "FundFreaks OTP";
            emailmessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Welcome to FundFreaks" + "\n" + rndOTP + "\n" + "\n Don't share your OTP with anyone " };

            var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailUserPassword").Value);
            smtp.Send(emailmessage);
            smtp.Disconnect(true);
            return true;
        }

        public bool SendMailMessage(Email email)
        {
            var emailmessage = new MimeMessage();
            emailmessage.From.Add(MailboxAddress.Parse(email.EmailId));
            emailmessage.To.Add(MailboxAddress.Parse(email.UserEmailId));
            emailmessage.Subject = "Fundfreaks";
            emailmessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.EmailBody };

            var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailUserPassword").Value);
            smtp.Send(emailmessage);
            smtp.Disconnect(true);
            return true;

        }
    }
}
