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
                         Id_Exam = new Guid("786c93d8-43c2-41b1-b681-82b69c055335"),
                         Id_Question_Bank = new Guid("5e25eaa8-569b-412b-af15-652e6adf8bf5"),
                         Count = 30,
                         IsDelete = "0"
                     },
                new Entities.Examination_Detail
                {
                    Id_Exam = new Guid("571cc92f-1abe-4856-8b69-be876bf0a5e5"),
                    Id_Question_Bank = new Guid("30a80941-7acb-421e-9504-3f2d6c1cccca"),
                    Count = 30,
                    IsDelete = "0"
                },
                new Entities.Examination_Detail
                {
                    Id_Exam = new Guid("b78c0f1d-60c3-4760-9241-c0fe443d02d5"),
                    Id_Question_Bank = new Guid("55ec968f-4971-487a-92cc-3452938610c7"),
                    Count = 30,
                    IsDelete = "0"
                }
            );
            context.SaveChanges();
                   

            }
        }
    }
}
