using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;

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
                        Content = "8 byte",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("883d469c-561d-4d9a-81c6-af5ce70ce3b3"),
                        IsCorrect = "0",
                        Content = "2 byte",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("883d469c-561d-4d9a-81c6-af5ce70ce3b3"),
                        IsCorrect = "0",
                        Content = "4 byte",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("883d469c-561d-4d9a-81c6-af5ce70ce3b3"),
                        IsCorrect = "0",
                        Content = "1 byte",
                        IsDelete = "0",
                    },

                    new Entities.Answer
                    {
                        Id_Question = new Guid("e859e5f3-a823-4656-927b-22240a759e7c"),
                        IsCorrect = "1",
                        Content = "View",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("e859e5f3-a823-4656-927b-22240a759e7c"),
                        IsCorrect = "0",
                        Content = "Controller",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("e859e5f3-a823-4656-927b-22240a759e7c"),
                        IsCorrect = "0",
                        Content = "Model",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("e859e5f3-a823-4656-927b-22240a759e7c"),
                        IsCorrect = "0",
                        Content = "Another answer",
                        IsDelete = "0",
                    },

                    new Entities.Answer
                    {
                        Id_Question = new Guid("b8b4048b-42b3-4fa7-8be9-e1ad4b6d4f70"),
                        IsCorrect = "1",
                        Content = "100",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("b8b4048b-42b3-4fa7-8be9-e1ad4b6d4f70"),
                        IsCorrect = "0",
                        Content = "10",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("b8b4048b-42b3-4fa7-8be9-e1ad4b6d4f70"),
                        IsCorrect = "0",
                        Content = "1",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("b8b4048b-42b3-4fa7-8be9-e1ad4b6d4f70"),
                        IsCorrect = "0",
                        Content = "1000",
                        IsDelete = "0",
                    },

                    new Entities.Answer
                    {
                        Id_Question = new Guid("8cf92cab-d94d-47ac-ac82-5f5f89f83a6d"),
                        IsCorrect = "1",
                        Content = "2 thang",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("8cf92cab-d94d-47ac-ac82-5f5f89f83a6d"),
                        IsCorrect = "0",
                        Content = "3 thang",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("8cf92cab-d94d-47ac-ac82-5f5f89f83a6d"),
                        IsCorrect = "0",
                        Content = "1 thang",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("8cf92cab-d94d-47ac-ac82-5f5f89f83a6d"),
                        IsCorrect = "0",
                        Content = "4 thang",
                        IsDelete = "0",
                    },

                    new Entities.Answer
                    {
                        Id_Question = new Guid("773cb41e-e609-485c-941d-9efdc7a73fc2"),
                        IsCorrect = "1",
                        Content = "35068",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("773cb41e-e609-485c-941d-9efdc7a73fc2"),
                        IsCorrect = "0",
                        Content = "3568",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("773cb41e-e609-485c-941d-9efdc7a73fc2"),
                        IsCorrect = "0",
                        Content = "3568",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("773cb41e-e609-485c-941d-9efdc7a73fc2"),
                        IsCorrect = "0",
                        Content = "3508",
                        IsDelete = "0",
                    },

                    new Entities.Answer
                    {
                        Id_Question = new Guid("3c6698b2-bfe9-4555-af52-7f4637a064b3"),
                        IsCorrect = "1",
                        Content = "10 nam",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("3c6698b2-bfe9-4555-af52-7f4637a064b3"),
                        IsCorrect = "0",
                        Content = "5 nam",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("3c6698b2-bfe9-4555-af52-7f4637a064b3"),
                        IsCorrect = "0",
                        Content = "2 nam",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("3c6698b2-bfe9-4555-af52-7f4637a064b3"),
                        IsCorrect = "0",
                        Content = "1 nam",
                        IsDelete = "0",
                    },

                    new Entities.Answer
                    {
                        Id_Question = new Guid("ad7340a3-ac88-40e6-866c-f699d91e9dfa"),
                        IsCorrect = "1",
                        Content = "P = m*g",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("ad7340a3-ac88-40e6-866c-f699d91e9dfa"),
                        IsCorrect = "0",
                        Content = "F = m*a",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("ad7340a3-ac88-40e6-866c-f699d91e9dfa"),
                        IsCorrect = "0",
                        Content = "F = m*g*s",
                        IsDelete = "0",
                    },
                    new Entities.Answer
                    {
                        Id_Question = new Guid("ad7340a3-ac88-40e6-866c-f699d91e9dfa"),
                        IsCorrect = "0",
                        Content = "Another answer",
                        IsDelete = "0",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}