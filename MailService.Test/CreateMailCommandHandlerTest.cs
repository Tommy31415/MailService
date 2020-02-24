using System.Linq;
using System.Threading;
using MailService.Commands;
using MailService.Handlers;
using MailService.Models;
using MailService.Requests;
using Xunit;

namespace MailService.Test
{
    public class CreateMailCommandHandlerTest : BaseTest
    {
        [Fact]
        public void ShouldReturnAllMails()
        {
            _dbContext.Database.EnsureDeleted();
            SetupDatabase();
            var createMailCommandHandler = new CreateMailCommandHandler(_dbContext);
            var result = createMailCommandHandler.Handle(new CreateMailCommand(){Mail = new Mail()}, CancellationToken.None);
            var mailCount = _dbContext.Mails.Count();
            Assert.Equal(3, mailCount);
        }

        public CreateMailCommandHandlerTest() : base("CreateMailCommandHandlerTest")
        {
        }
    }
}