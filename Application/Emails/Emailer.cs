using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Application.Emails
{
    public class Emailer : IEmailer
    {
        private readonly EmailSettings settings;
        public Emailer(IOptions<EmailSettings> emailSettingOptions)
        {
            settings = emailSettingOptions.Value;
        }
        public bool TrySendEmail(string to, string subject, string message)
        {
            bool bSend = false;
            //using (MailMessage mm = new MailMessage(settings.From, settings.Password))
            //{
            //    mm.Subject = subject;
            //    mm.Body = message;
            //    //if (model.Attachment.Length > 0)
            //    //{
            //    //    string fileName = Path.GetFileName(model.Attachment.FileName);
            //    //    mm.Attachments.Add(new Attachment(model.Attachment.OpenReadStream(), fileName));
            //    //}
            //    mm.IsBodyHtml = true;
            //    using (SmtpClient smtp = new SmtpClient())
            //    {
            //        smtp.Host = settings.Host;
            //        smtp.EnableSsl = true;
            //        NetworkCredential NetworkCred = new NetworkCredential(settings.From, settings.Password);
            //        smtp.UseDefaultCredentials = true;
            //        smtp.Credentials = NetworkCred;
            //        smtp.Port = settings.Port;
            //        smtp.Send(mm);
            //        bSend = true;
            //    }
            //}

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(settings.From);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient(settings.Host, settings.Port))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(settings.From, settings.AppPWD);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    bSend = true;
                }
            }

            return bSend;
        }
    }
}
