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
                        ID_Exam = Guid.NewGuid(),
                        Email_User = "thanhnq@gmail.com",
                        Date_Do_Exam = DateTime.Now,
                        ID_Question = new Guid("86bb6ed2-e395-4cb0-a0ef-0423b19c09bf"),
                        ID_Answer_Chose = "123",
                        IsDelete = "0"
                    },
                    new Entities.Exam_History_Detail
                    {
                        ID_Exam = Guid.NewGuid(),
                        Email_User = "trieu@gmail.com",
                        Date_Do_Exam = DateTime.Now,
                        ID_Question = new Guid("f8bcc8ea-001c-4011-a213-fb9e1e20785a"),
                        ID_Answer_Chose = "456",
                        IsDelete = "0"
                    },
                    new Entities.Exam_History_Detail
                    {
                        ID_Exam = Guid.NewGuid(),
                        Email_User = "huyln@gmail.com",
                        Date_Do_Exam = DateTime.Now,
                        ID_Question = new Guid("d5d25730-9353-4a57-952e-0c39d2614b7c"),
                        ID_Answer_Chose = "789",
                        IsDelete = "0"
                    });
                    
            }
        }
    }
}
