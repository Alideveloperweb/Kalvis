using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Common.Sender
{
    public class SendEmail
    {
        public static bool Send(string to, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage("Atom100.help@gmail.com", to)
                {
                    Body = body,
                    Subject = subject,
                    IsBodyHtml = true
                };

                NetworkCredential mailAuthentication =
               new NetworkCredential("Atom100.help@gmail.com"
               , "0480902542");

                SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = mailAuthentication
                };
                mailClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

