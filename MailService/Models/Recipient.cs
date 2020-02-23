namespace MailService.Models
{
    public class Recipient
    {
        public int RecipientId { get; set; }
        public string Email { get; set; }

        public Mail Mail { get; set; }
    }
}