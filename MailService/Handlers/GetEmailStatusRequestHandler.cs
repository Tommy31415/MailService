using System;
using System.Threading;
using System.Threading.Tasks;
using MailService.Data;
using MailService.Models;
using MailService.Requests;
using MediatR;

namespace MailService.Handlers
{
    public class GetEmailStatusRequestHandler : IRequestHandler<GetEmailStatusRequest, MailHeader>
    {
        private readonly DataContext _context;

        public GetEmailStatusRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<MailHeader> Handle(GetEmailStatusRequest request, CancellationToken cancellationToken)
        {
            var mail = await _context.Mails.FindAsync(request.Id);
            //return mail?.Header;
            throw  new NotImplementedException();
        }
    }
}