using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;

namespace Quiz.Database.Migrations
{
    public class SeedData_Exam_History_Detail
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                if (context.Exam_History_Details.Any())
                {
                    return;
                }
                context.Exam_History_Details.AddRange(
                    new Entities.Exam_History_Detail
                    {
                        ID_Exam = new Guid("786c93d8-43c2-41b1-b681-82b69c055335"),
                        Email_User = "thanhnq@gmail.com",
                        Date_Do_Exam = DateTime.Parse("1989-2-12"),
                        ID_Question = new Guid("883d469c-561d-4d9a-81c6-af5ce70ce3b3"),
                        ID_Answer_Chose = "123",
                        IsDelete = "0"
                    },
                    new Entities.Exam_History_Detail
                    {
                        ID_Exam = new Guid("571cc92f-1abe-4856-8b69-be876bf0a5e5"),
                        Email_User = "trieu@gmail.com",
                        Date_Do_Exam = DateTime.Parse("1984-3-13"),
                        ID_Question = new Guid("e859e5f3-a823-4656-927b-22240a759e7c"),
                        ID_Answer_Chose = "456",
                        IsDelete = "0"
                    },
                    new Entities.Exam_History_Detail
                    {
                        ID_Exam = new Guid("b78c0f1d-60c3-4760-9241-c0fe443d02d5"),
                        Email_User = "huyln@gmail.com",
                        Date_Do_Exam = DateTime.Parse("1986-2-23"),
                        ID_Question = new Guid("b8b4048b-42b3-4fa7-8be9-e1ad4b6d4f70"),
                        ID_Answer_Chose = "789",
                        IsDelete = "0"
                    });
                context.SaveChanges();
            }
        }
    }
}