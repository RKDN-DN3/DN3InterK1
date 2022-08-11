using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;

namespace Quiz.Database.Migrations
{
    public class SeedData_List_Question_In_Exam
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new ApplicationDBContext(serviceProvider.GetRequiredService<
            //    DbContextOptions<ApplicationDBContext>>()))
            //{
            //    if (context.Examinations.Any())
            //    {
            //        return;
            //    }

            //    context.Examinations.AddRange(
            //        new Entities.Examination
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "Thi đánh giá năng lực",
            //            ShortDes = "Nhằm đánh giá kết quả học tập của SV",
            //            Content = "Bài kiểm tra gồm các KTXH",
            //            Duration = 30,
            //            NumberOfQuestions = 15,
            //            IsTimeRetricted = "1",
            //            IsDelete = "0"
            //        },

            //        new Entities.Examination
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "Thi học kỳ 1",
            //            ShortDes = "Kì thi kết thúc học kì 1",
            //            Content = "Kì thi gồm các môn CNPM, thuật toán logic",
            //            Duration = 40,
            //            NumberOfQuestions = 30,
            //            IsTimeRetricted = "1",
            //            IsDelete = "0"
            //        },

            //        new Entities.Examination
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "Thi đố vui",
            //            ShortDes = "Quiz đố vui nhằm giải trí sau giờ học căng thẳng",
            //            Content = "Kì thi gồm các môn CNPM, thuật toán logic",
            //            Duration = 20,
            //            NumberOfQuestions = 10,
            //            IsTimeRetricted = "1",
            //            IsDelete = "0"
            //        }
            //    );
            //    context.SaveChanges();

            //}
        }
    }
}
