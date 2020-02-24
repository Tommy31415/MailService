using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mail>()
                .Property(e => e.Recipients)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }

        public DbSet<Mail> Mails { get; set; }

    }
}