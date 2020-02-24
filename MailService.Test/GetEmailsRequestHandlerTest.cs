using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using MailService.Handlers;
using MailService.Requests;
using Xunit;

namespace MailService.Test
{
    public class GetEmailsRequestHandlerTest : BaseTest
    {
        [Fact]
        public void ShouldReturnAllMails()
        {
            _dbContext.Database.EnsureDeleted();
            SetupDatabase();
            var getEmailsRequestHandler = new GetEmailsRequestHandler(_dbContext);
            var result = getEmailsRequestHandler.Handle(new GetEmailsRequest(), CancellationToken.None);
            Assert.Equal(2, result.Result.Length);
        }

        public GetEmailsRequestHandlerTest() : base("GetEmailsRequestHandlerTest")
        {
        }
    }
}
