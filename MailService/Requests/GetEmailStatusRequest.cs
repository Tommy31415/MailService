using MailService.Models;
using MediatR;

namespace MailService.Requests
{
    public class GetEmailStatusRequest : IRequest<MailHeader>
    {
        public long Id { get; }

        public GetEmailStatusRequest(in long id)
        {
            Id = id;
        }
    }
}