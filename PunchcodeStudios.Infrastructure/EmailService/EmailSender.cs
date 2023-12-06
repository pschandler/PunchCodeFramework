using System;
using PunchcodeStudios.Application.Contracts.Email;
using PunchcodeStudios.Application.Models.Email;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PunchcodeStudios.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public PunchcodeEmailSettings _emailSettings { get; }
        public EmailSender(IOptions<PunchcodeEmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(PunchcodeEmail email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email  = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }
    }
}
