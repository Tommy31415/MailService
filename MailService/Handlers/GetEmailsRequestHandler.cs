using System.Threading;
using System.Threading.Tasks;
using MailService.Data;
using MailService.Models;
using MailService.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MailService.Handlers
{
    public class GetEmailsRequestHandler : IRequestHandler<GetEmailsRequest, Mail[]>
    {
        private readonly DataContext _context;

        public GetEmailsRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Mail[]> Handle(GetEmailsRequest request, CancellationToken cancellationToken)
        {
            return await _context.Mails.ToArrayAsync(cancellationToken);
        }
    }
}
