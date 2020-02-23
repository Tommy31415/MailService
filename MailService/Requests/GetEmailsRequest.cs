using MailService.Models;
using MediatR;

namespace MailService.Requests
{
    public class GetEmailsRequest : IRequest<Mail[]>
    {
    }
}