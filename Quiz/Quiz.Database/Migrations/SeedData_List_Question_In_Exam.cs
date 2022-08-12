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
    public class SeedData_List_Question_In_Exam
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            { 
                if (context.List_Question_In_Exam.Any())
                {
                    return;
                }
            }
        }
    }
}
