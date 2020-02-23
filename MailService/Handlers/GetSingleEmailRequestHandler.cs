using System.Threading;
using System.Threading.Tasks;
using MailService.Data;
using MailService.Models;
using MailService.Requests;
using MediatR;

namespace MailService.Handlers
{
    public class GetSingleEmailRequestHandler : IRequestHandler<GetSingleEmailRequest, Mail>
    {
        private readonly DataContext _context;

        public GetSingleEmailRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Mail> Handle(GetSingleEmailRequest request, CancellationToken cancellationToken)
        {
            return await _context.Mails.FindAsync(request.Id);
        }
    }
}