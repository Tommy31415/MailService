using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailService.Models
{
    public class MailHeader
    {
        public int Id { get; set; }
        public EMailStatus MailStatus { get; set; }

        public ICollection<Recipient> Recipients { get; set; }

        public string SenderEmail { get; set; }
        public string Title { get; set; }
    }
}