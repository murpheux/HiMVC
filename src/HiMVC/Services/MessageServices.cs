using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HiMVC.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            MailMessage mail
                = new MailMessage("dapo.onawole@gmail.com", email, subject, message);
            //mail.Attachments.Add(new Attachment("file://"));

            using (var smtpClient = new SmtpClient())
            {

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential("dapo.onawole@gmail.com", "xxx");
                smtpClient.Timeout = 20000;

                smtpClient.SendCompleted += (s, e) =>
                {
                    smtpClient.Dispose();
                    mail.Dispose();
                };

                try
                {
                    smtpClient.SendAsync(mail, null);
                }
                catch (Exception ex) { }

            }
            return Task.FromResult(0);
        }


        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
