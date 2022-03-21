using EmailBot.Common.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailBot.Common.Helpers
{
    public class SendMailHelper
    {
        public static void SendMail(UserEntity user)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("hiba@hibaazhari.onmicrosoft.com"),
                Subject = "Registered Email",
                Body = "Hi " + user.Name + " from " + user.Department + ". Thank you for signing up!"
            };

            mailMessage.To.Add(user.AltEmail);

            var smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential("hiba@hibaazhari.onmicrosoft.com", "Zi7Minni99"),
                Host = "smtp.office365.com",
                Port = 587
            };

            smtpClient.Send(mailMessage);
        }

    }
}
