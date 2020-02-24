using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MailService.Data;
using MailService.Models;
using MailService.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MailService.Handlers
{
    public class SendAllPendingEmailsRequestHandler : IRequestHandler<SendAllPendingEmailsRequest, MailSummary[]>
    {
        private readonly DataContext _context;
        private readonly IMailSender _mailSender;

        public SendAllPendingEmailsRequestHandler(DataContext context, IMailSender mailSender)
        {
            _context = context;
            _mailSender = mailSender;
        }

        public async Task<MailSummary[]> Handle(SendAllPendingEmailsRequest request, CancellationToken cancellationToken)
        {
            var sentMailList = new List<MailSummary>();
            var mails = await _context.Mails.ToListAsync(cancellationToken);
            foreach (var mail in mails)
            {
                if (mail.MailStatus == EMailStatus.Pending)
                {
                    try
                    {
                        _mailSender.Send(mail);
                        mail.MailStatus = EMailStatus.Sent;
                        sentMailList.Add(new MailSummary(EMailStatus.Sent,mail.Title));
                    }
                    catch 
                    {
                        mail.MailStatus = EMailStatus.Invalid;
                        sentMailList.Add(new MailSummary(EMailStatus.Invalid, mail.Title));
                    }
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            return sentMailList.ToArray();
        }
    }
}