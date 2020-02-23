using System.Net.Mail;
using System.Reflection;

namespace SmtpWrapper
{
    public class SmtpClientAdapter : ISmtpClientAdapter
    {
        private readonly SmtpClient _smtpClient;

        public SmtpClientAdapter(string host, int port)
        {
            _smtpClient = new SmtpClient(host, port) {UseDefaultCredentials = true};
        }

        public virtual void Send(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);
        }
    }
}
