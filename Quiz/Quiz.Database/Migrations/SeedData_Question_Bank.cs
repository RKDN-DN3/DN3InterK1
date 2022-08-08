using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;
using Quiz.Entities;


namespace Quiz.Database.Migrations
{
    public class SeedData_Question_Bank
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDBContext>>()))
            {
                if (context.Question_Banks.Any())
                {
                    return;
                }

                context.Question_Banks.AddRange(
                    new Entities.Question_Bank
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bo cau hoi Toan hoc",
                        IsDelete = "0"
                    },

                    new Entities.Question_Bank
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bo cau hoi VatLy",
                        IsDelete = "0"
                    },

                    new Entities.Question_Bank
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bo cau hoi Logic",
                        IsDelete = "0"
                    },

                    new Entities.Question_Bank
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bo cau hoi Sinh hoc",
                        IsDelete = "0"
                    }

                );
                context.SaveChanges();

            }
        }
    }
}

