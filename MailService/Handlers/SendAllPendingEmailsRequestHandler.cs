using System.Threading;
using System.Threading.Tasks;
using MailService.Data;
using MailService.Models;
using MailService.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MailService.Handlers
{
    public class SendAllPendingEmailsRequestHandler : IRequestHandler<SendAllPendingEmailsRequest, MailHeader[]>
    {
        private readonly DataContext _context;
        private readonly IMailSender _mailSender;

        public SendAllPendingEmailsRequestHandler(DataContext context, IMailSender mailSender)
        {
            _context = context;
            _mailSender = mailSender;
        }

        public async Task<MailHeader[]> Handle(SendAllPendingEmailsRequest request, CancellationToken cancellationToken)
        {
            var mails = await _context.Mails.ToListAsync(cancellationToken);
            foreach (var mail in mails)
            {
                _mailSender.Send(mail);
            }

            return null;
        }
    }
}