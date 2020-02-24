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

        public string[] Recipients { get; set; }

        public string SenderEmail { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        
    }
}
