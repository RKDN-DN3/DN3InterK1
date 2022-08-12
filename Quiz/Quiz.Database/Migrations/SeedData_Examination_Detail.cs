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
    public class SeedData_Examination_Detail
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDBContext>>()))
            {
                if (context.Examination_Details.Any())
                {
                    return;
                }
                context.Examination_Details.AddRange(
                     new Entities.Examination_Detail
                     {
                         Id_Exam = Guid.NewGuid(),
                         Id_Question_Bank = new Guid("585a7bea-bfdc-4cb8-a933-a733856a8a95"),
                         Count = 30,
                         IsDelete = "0"
                     },
                new Entities.Examination_Detail
                {
                    Id_Exam = Guid.NewGuid(),
                    Id_Question_Bank = new Guid("8c523d03-21e1-4582-a923-426bd7336e77"),
                    Count = 30,
                    IsDelete = "0"
                },
                new Entities.Examination_Detail
                {
                    Id_Exam = Guid.NewGuid(),
                    Id_Question_Bank = new Guid("f040d249-8914-4095-94ff-1747cb16770d"),
                    Count = 30,
                    IsDelete = "0"
                },
                 new Entities.Examination_Detail
                 {
                     Id_Exam = Guid.NewGuid(),
                     Id_Question_Bank = new Guid("426a6aa4-6818-497d-8ad2-3ec94d9e8a6f"),
                     Count = 30,
                     IsDelete = "0"
                 },
                  new Entities.Examination_Detail
                  {
                      Id_Exam = Guid.NewGuid(),
                      Id_Question_Bank = new Guid("3f26465a-8950-4bb8-8d1a-b0d28ce77cb7"),
                      Count = 30,
                      IsDelete = "0"
                  });
                context.SaveChanges();
                   

            }
        }
    }
}
