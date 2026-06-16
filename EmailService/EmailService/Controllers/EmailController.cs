using EmailService.Exception;
using EmailService.Model;
using EmailService.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;

namespace EmailService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        IEmailServices _emailService;
        public EmailController(IEmailServices emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        [Route("EmailOTP")]
        public IActionResult SendEmailForOtp(string userEmail)
        {
            try
            {
                bool emailStatus = _emailService.SendEmailOtpToUser(userEmail);
                return Ok(emailStatus);
            }
            catch (EmailNotSentExceptiom ufx)
            {
                return BadRequest(ufx.Message);
            }
        }

        [HttpPost]
        [Route("EmailMessage")]
        public IActionResult SendEmailMessage(Email email)
        {
            try
            {
                bool emailStatus = _emailService.SendEmailMessageToUser(email);
                return Ok(emailStatus);
            }
            catch (EmailNotSentExceptiom ufx)
            {
                return BadRequest(ufx.Message);
            }

        }


    }
}
