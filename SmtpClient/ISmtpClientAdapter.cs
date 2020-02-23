using System.Net.Mail;

namespace SmtpWrapper
{
    public interface ISmtpClientAdapter
    {
        void Send(MailMessage mailMessage);
    }
}