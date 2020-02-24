using System.Threading;
using MailService.Handlers;
using MailService.Requests;
using Xunit;

namespace MailService.Test
{
    public class GetEmailStatusRequestHandlerTest : BaseTest
    {
        [Fact]
        public void ShouldReturnMailStatusWithGivenId()
        {
            _dbContext.Database.EnsureDeleted();
            SetupDatabase();
            var getEmailStatusRequestHandler = new GetEmailStatusRequestHandler(_dbContext);
            var result = getEmailStatusRequestHandler.Handle(new GetEmailStatusRequest(1), CancellationToken.None);
            Assert.NotNull(result.Result);
        }

        public GetEmailStatusRequestHandlerTest() : base("GetEmailStatusRequestHandlerTest")
        {
        }
    }
}