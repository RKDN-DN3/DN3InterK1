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
    internal class SeedData_Exam_History
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                // Look for any movies.
                //if (context.Exam_Historys.Any())
                //{
                //    return;   // DB has been seeded
                //}
                //context.Exam_Historys.AddRange(
                //    new Entities.Exam_History
                //    {
                //        Mark = 10,
                //        TimeDoExam = 30,
                //        StartTime = DateTime.Now,
                //        EndTime = DateTime.Now,
                //        IsDelete = "0"
                //    },
                //    new Entities.Exam_History
                //    {
                //        Mark = 9,
                //        TimeDoExam = 30,
                //        StartTime = DateTime.Now,
                //        EndTime = DateTime.Now,
                //        IsDelete = "0"
                //    },
                //    new Entities.Exam_History
                //    {
                //        Mark = 8,
                //        TimeDoExam = 30,
                //        StartTime = DateTime.Now,
                //        EndTime = DateTime.Now,
                //        IsDelete = "0"
                //    }

                //    );

            }
        }

    }
}
