using MailService.Models;

namespace MailService.Handlers
{
    public interface IMailSender
    {
        void Send(Mail mail);
    }
}