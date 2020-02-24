using System;
using System.Collections.Generic;
using System.Net.Mail;
using MailService.Handlers;
using MailService.Models;
using Moq;
using SmtpWrapper;
using Xunit;

namespace MailService.Test
{
    public class MailSenderTest
    {
        [Fact]
        public void ShouldSendEmail()
        {
            var smtpClientAdapter = new Mock<ISmtpClientAdapter>();
            var mailSender = new MailSender(smtpClientAdapter.Object);
            mailSender.Send(new Mail(){Body = "test",Id=0,MailStatus = EMailStatus.Pending,Recipients = new string[]{"jhon@gmail"},SenderEmail = "aaa@bbbb",Title = "title"});
            smtpClientAdapter.Verify(m => m.Send(It.IsAny<MailMessage>()), Times.Once);
        }
    }
}
