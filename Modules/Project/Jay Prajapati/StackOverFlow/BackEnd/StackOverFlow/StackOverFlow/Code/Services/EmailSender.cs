using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StackOverFlow.Code.Services
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            var mailMessage = new MailMessage(fromAddress, toAddress, subject, message);
            using (var client = new SmtpClient(_config["SMTPEmail:Host"], int.Parse(_config["SMTPEmail:Port"])) {
                Credentials = new NetworkCredential(_config["SMTPEmail:Username"],_config["SMTPEmail:Password"])
            })
            {
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
