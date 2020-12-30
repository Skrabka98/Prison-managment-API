﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonBack.Mailing.Service
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly RegisterMail _registerMail;
        public MailService(IOptions<MailSettings> mailSettings,  RegisterMail registerMail)
        {
            _mailSettings = mailSettings.Value;
            _registerMail = registerMail;
        }

        public async Task SendEmailAsync(MailRequest mailRequest, string userName)
        {
            mailRequest.Body = _registerMail.Body(userName);
            mailRequest.Subject = _registerMail.Title();
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
