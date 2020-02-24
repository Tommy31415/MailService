using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailService.Models
{
    public class MailSummary
    {
        public MailSummary(EMailStatus mailStatus, string title)
        {
            MailStatus = mailStatus;
            Title = title;
        }

        public EMailStatus MailStatus { get; set; }

        public string Title { get; set; }
    }
}