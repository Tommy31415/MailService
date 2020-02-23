using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MailService.Models
{
    public class Mail
    {
        public long Id { get; set; }

        public EMailStatus MailStatus { get; set; }

        public ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();

        public string SenderEmail { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        
    }
}
