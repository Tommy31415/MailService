using System.Threading;
using MailService.Data;
using MailService.Handlers;
using MailService.Models;
using MailService.Requests;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace MailService.Test
{
    public class SendAllPendingEmailsRequestHandlerTest : BaseTest
    {
        [Fact]
        public void ShouldSendOnlyOneEmailFromList()
        {
            _dbContext.Database.EnsureDeleted();
            SetupDatabase();
            var mailSenderMock = new Mock<IMailSender>();
            var ss = new SendAllPendingEmailsRequestHandler(_dbContext,mailSenderMock.Object);
            ss.Handle(new SendAllPendingEmailsRequest(), CancellationToken.None);
            mailSenderMock.Verify(m => m.Send(It.IsAny<Mail>()), Times.Once);
        }

        public SendAllPendingEmailsRequestHandlerTest() : base("SendAllPendingEmailsRequestHandlerTest")
        {
        }
    }
}