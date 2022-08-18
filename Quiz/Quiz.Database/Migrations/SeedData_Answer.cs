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
                        Id_Question = new Guid("883d469c-561d-4d9a-81c6-af5ce70ce3b3"),
                        IsCorrect = "1",
                        Content = "1234",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("e859e5f3-a823-4656-927b-22240a759e7c"),
                        IsCorrect = "0",
                        Content = "23894",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("b8b4048b-42b3-4fa7-8be9-e1ad4b6d4f70"),
                        IsCorrect = "1",
                        Content = "abcd",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("8cf92cab-d94d-47ac-ac82-5f5f89f83a6d"),
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