using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;

namespace Quiz.Web.Models
{
    public class SeedData__Account
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                // Look for any movies.
                if (context.Accounts.Any())
                {
                    return;   // DB has been seeded
                }
                context.Accounts.AddRange(
                    new Entities.Accounts
                    {
                        Email_User = "huyln@gmail.com",
                        Password = "huy123",
                        Authority = "0",
                        Name = "huy",
                        DOB = "02/12/2001",
                        PhoneNumber = "0325880124",
                        IsDelete = "0",
                        CreateDate = DateTime.Now,
                        UserCreate = Guid.NewGuid(),
                        UpdateDate = DateTime.Now,
                        UserUpdate = Guid.NewGuid(),
                    },
                    new Entities.Accounts
                    {
                        Email_User = "thanhnq@gmail.com",
                        Password = "thanh123",
                        Authority = "0",
                        Name = "thanh",
                        DOB = "14/6/2002",
                        PhoneNumber = "0325880125",
                        IsDelete = "1",
                        CreateDate = DateTime.Now,
                        UserCreate = Guid.NewGuid(),
                        UpdateDate = DateTime.Now,
                        UserUpdate = Guid.NewGuid(),

                    },
                    new Entities.Accounts
                    {
                        Email_User = "trieu@gmail.com",
                        Password = "trieu123",
                        Authority = "1",
                        Name = "trieu",
                        DOB = "30/9/2001",
                        PhoneNumber = "0325880125",
                        IsDelete = "1",
                        CreateDate = DateTime.Now,
                        UserCreate = Guid.NewGuid(),
                        UpdateDate = DateTime.Now,
                        UserUpdate = Guid.NewGuid(),
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
