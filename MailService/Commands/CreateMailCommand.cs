using MailService.Models;
using MediatR;

namespace MailService.Commands
{
    public class CreateMailCommand : INotification
    {
        public Mail Mail { get; set; }
    }
}