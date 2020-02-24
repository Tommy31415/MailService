using System.Threading;
using MailService.Handlers;
using MailService.Requests;
using Xunit;

namespace MailService.Test
{
    public class GetSingleEmailRequestHandlerTest :BaseTest
    {
        [Fact]
        public void ShouldReturnMailWithGivenId()
        {
            _dbContext.Database.EnsureDeleted();
            SetupDatabase();
            var ss = new GetSingleEmailRequestHandler(_dbContext);
            var result = ss.Handle(new GetSingleEmailRequest(1), CancellationToken.None);
            Assert.NotNull(result.Result);
        }

        public GetSingleEmailRequestHandlerTest() : base("GetSingleEmailRequestHandlerTest")
        {
        }
    }
}