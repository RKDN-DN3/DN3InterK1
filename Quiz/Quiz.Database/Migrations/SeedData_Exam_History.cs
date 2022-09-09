using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;

namespace Quiz.Database.Migrations
{
    public class SeedData_Exam_History
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                if (context.Exam_Historys.Any())
                {
                    return;
                }
                context.Exam_Historys.AddRange(
                    new Entities.Exam_History
                    {
                        ID_Exam = new Guid("b78c0f1d-60c3-4760-9241-c0fe443d02d5"),
                        Email_User = "thanhnq@gmail.com",
                        DateDoExam = DateTime.Parse("2020-2-12"),
                        Mark = 10,
                        TimeDoExam = 30,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        IsDelete = "0"
                    },
                    new Entities.Exam_History
                    {
                        ID_Exam = new Guid("786c93d8-43c2-41b1-b681-82b69c055335"),
                        Email_User = "thanhnq@gmail.com",
                        DateDoExam = DateTime.Parse("2021-3-6"),
                        Mark = 9,
                        TimeDoExam = 25,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        IsDelete = "0"
                    },
                    new Entities.Exam_History
                    {
                        ID_Exam = new Guid("571cc92f-1abe-4856-8b69-be876bf0a5e5"),
                        Email_User = "thanhnq@gmail.com",
                        DateDoExam = DateTime.Parse("2021-7-4"),
                        Mark = 7,
                        TimeDoExam = 20,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        IsDelete = "0"
                    },
                    new Entities.Exam_History
                    {
                        ID_Exam = new Guid("571cc92f-1abe-4856-8b69-be876bf0a5e5"),
                        Email_User = "trieu@gmail.com",
                        DateDoExam = DateTime.Parse("1984-3-13"),
                        Mark = 9,
                        TimeDoExam = 30,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        IsDelete = "0"
                    },
                    new Entities.Exam_History
                    {
                        ID_Exam = new Guid("b78c0f1d-60c3-4760-9241-c0fe443d02d5"),
                        Email_User = "huyln@gmail.com",
                        DateDoExam = DateTime.Parse("1986-2-23"),
                        Mark = 8,
                        TimeDoExam = 30,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        IsDelete = "0"
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}