using MailService.Models;
using MediatR;

namespace MailService.Requests
{
    public class GetSingleEmailRequest : IRequest<Mail>
    {
        public long Id { get; }

        public GetSingleEmailRequest(in long id)
        {
            Id = id;
        }
    }
}