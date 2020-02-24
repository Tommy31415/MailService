using MailService.Data;
using MailService.Models;
using Microsoft.EntityFrameworkCore;

namespace MailService.Test
{
    public class BaseTest
    {
        protected DataContext _dbContext;

        protected BaseTest(string dbname)
        {
            InitDataContext(dbname);
        }

        private void InitDataContext(string dbname)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase(dbname);
            _dbContext = new DataContext(optionsBuilder.Options);
        }

        protected void SetupDatabase()
        {
            _dbContext.Mails.Add(new Mail
            {
                Id = 1,
                Body = "body1",
                Title = "title1",
                MailStatus = EMailStatus.Pending,
                SenderEmail = "jhon@gmail.com",
                Recipients = new[] { "mary@gmail.com", "elena@gmail.com" }
            });
            _dbContext.Mails.Add(new Mail
            {
                Id = 2,
                Body = "body2",
                Title = "title3",
                MailStatus = EMailStatus.Sent,
                SenderEmail = "mary@gmail.com",
                Recipients = new[] { "jhon@gmail.com", "elena@gmail.com" }
            });
            _dbContext.SaveChanges();
        }
    }
}