using System.Threading;
using System.Threading.Tasks;
using MailService.Commands;
using MailService.Data;
using MediatR;

namespace MailService.Handlers
{
    public class CreateMailCommandHandler : INotificationHandler<CreateMailCommand>
    {
        private readonly DataContext _context;

        public CreateMailCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateMailCommand notification, CancellationToken cancellationToken)
        {
            
            _context.Mails.Add(notification.Mail);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}