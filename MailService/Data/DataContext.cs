using MailService.Models;
using Microsoft.EntityFrameworkCore;

namespace MailService.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Mail> Mails { get; set; }

    }
}