using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;

namespace Quiz.Database.Migrations
{
    public class SeedData_List_Question_In_Exam
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                if (context.List_Question_In_Exams.Any())
                {
                    return;
                }
                context.List_Question_In_Exams.AddRange(
                    new Entities.List_Question_In_Exam
                    {
                        Id_Exam = new Guid("786c93d8-43c2-41b1-b681-82b69c055335"),
                        Id_Question = new Guid("883d469c-561d-4d9a-81c6-af5ce70ce3b3"),
                        //index = 1,
                        IsDelete = "0"
                    },
                     new Entities.List_Question_In_Exam
                     {
                         Id_Exam = new Guid("571cc92f-1abe-4856-8b69-be876bf0a5e5"),
                         Id_Question = new Guid("e859e5f3-a823-4656-927b-22240a759e7c"),
                         //index = 2,
                         IsDelete = "0"
                     },
                      new Entities.List_Question_In_Exam
                      {
                          Id_Exam = new Guid("b78c0f1d-60c3-4760-9241-c0fe443d02d5"),
                          Id_Question = new Guid("b8b4048b-42b3-4fa7-8be9-e1ad4b6d4f70"),
                          //index = 3,
                          IsDelete = "0"
                      });
                context.SaveChanges();
            }
        }
    }
}