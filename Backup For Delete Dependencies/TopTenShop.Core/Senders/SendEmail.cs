using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TopTenShop.Core.Senders
{
    public class SendEmail
    {
        public static void Send(string To,string Subject,string Body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("morteza.f1378@gmail.com","تاپتن");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            //mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("Morteza.f1378@gmail.com", "jbch acox eyot xwue");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

        public static void Send2(string To, string Subject, string Body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("Morteza.f1378@gmail.com");
                mail.To.Add(To);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("Morteza.f1378@gmail.com", "m9o4t5z3a");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}