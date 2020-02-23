using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using MailService.Models;
using SmtpWrapper;

namespace MailService.Handlers
{
    public class MailSender : IMailSender
    {
        private readonly ISmtpClientAdapter _smtpClientAdapter;

        public MailSender(ISmtpClientAdapter smtpClientAdapter)
        {
            _smtpClientAdapter = smtpClientAdapter;
        }

        private static MailMessage CreateMailMessage(Mail mail)
        {
            var mailMessage = new MailMessage {Subject = mail.Title, IsBodyHtml = false};
            mailMessage.ReplyToList.Add(mail.SenderEmail);
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.HeadersEncoding = Encoding.UTF8;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            foreach (var headerRecipient in mail.Recipients)
            {
                mailMessage.To.Add(headerRecipient.Email);
            }

            var plainView =
                AlternateView.CreateAlternateViewFromString(mail.Body, mailMessage.BodyEncoding, "text/plain");
            plainView.TransferEncoding = TransferEncoding.SevenBit;
            mailMessage.AlternateViews.Add(plainView);

            return mailMessage;
        }

        public void Send(Mail mail)
        {
            _smtpClientAdapter.Send(CreateMailMessage(mail));
        }
    }
}