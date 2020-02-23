using MailService.Models;
using MediatR;

namespace MailService.Requests
{
    public class SendAllPendingEmailsRequest : IRequest<MailHeader[]>
    {
    }
}