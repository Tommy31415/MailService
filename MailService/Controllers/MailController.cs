using System.Threading.Tasks;
using MailService.Commands;
using MailService.Handlers;
using MailService.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmails()
        {
            return await ExecuteRequest(new GetEmailsRequest());
        }

        [HttpGet("SendAllPending")]
        public async Task<IActionResult> SendAllPending()
        {
            return await ExecuteRequest(new SendAllPendingEmailsRequest());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmail(long id)
        {
            return await ExecuteRequest(new GetSingleEmailRequest(id));
        }

        [HttpGet("status/{id}")]
        public async Task<IActionResult> GetEmailStatus(long id)
        {
            return await ExecuteRequest(new GetEmailStatusRequest(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMail(CreateMailCommand command)
        {
            return await ExecuteCommand(command);
        }

        #region MediatrWrapper
        
        private async Task<IActionResult> ExecuteCommand(INotification command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        private async Task<IActionResult> ExecuteRequest<T>(IRequest<T> request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        #endregion

    }
}
