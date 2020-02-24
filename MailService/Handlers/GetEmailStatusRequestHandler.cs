using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MailService.Data;
using MailService.Models;
using MailService.Requests;
using MediatR;

namespace MailService.Handlers
{
    public class GetEmailStatusRequestHandler : IRequestHandler<GetEmailStatusRequest, MailSummary>
    {
        private readonly DataContext _context;

        public GetEmailStatusRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<MailSummary> Handle(GetEmailStatusRequest request, CancellationToken cancellationToken)
        {
            var mail = await _context.Mails.FindAsync(request.Id);
            return new MailSummary(mail.MailStatus, mail.Title);
        }
    }
}