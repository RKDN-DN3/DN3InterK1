using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Database.Migrations
{
    public class SeedData_Answer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                // Look for any movies.
                if (context.Answers.Any())
                {
                    return;   // DB has been seeded
                }
                context.Answers.AddRange(
                    new Entities.Answer
                    {
                        ID_Question = "1",
                        IsCorrect = "1",
                        Content = "1234",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        ID_Question = "1",
                        IsCorrect = "0",
                        Content = "23894",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        ID_Question = "2",
                        IsCorrect = "1",
                        Content = "abcd",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        ID_Question = "2",
                        IsCorrect = "1",
                        Content = "123",
                        IsDelete = "0",
                    }

                );
                context.SaveChanges();

            }
        }
    }
}
