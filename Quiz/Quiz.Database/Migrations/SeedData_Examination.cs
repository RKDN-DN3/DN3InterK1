﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;


namespace Quiz.Database.Models
{
    public class SeedData_Examination
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDBContext>>()))
            {
                if (context.Examinations.Any())
                {
                    return;
                }

                context.Examinations.AddRange(
                    new Entities.Examination
                    {
                        Id = new Guid("786c93d8-43c2-41b1-b681-82b69c055335"),
                        Name = "Thi đánh giá năng lực",
                        ShortDes = "Nhằm đánh giá kết quả học tập của SV",
                        Content = "Bài kiểm tra gồm các KTXH",
                        Duration = 30,
                        NumberOfQuestions = 15,
                        IsTimeRetricted = "1",
                        UserCreate = "thanhnq@gmail.com",
                        IsDelete ="0"
                    },

                    new Entities.Examination
                    {
                        Id = new Guid("571cc92f-1abe-4856-8b69-be876bf0a5e5"),
                        Name = "Thi học kỳ 1",
                        ShortDes = "Kì thi kết thúc học kì 1",
                        Content = "Kì thi gồm các môn CNPM, thuật toán logic",
                        Duration = 40,
                        NumberOfQuestions = 30,
                        IsTimeRetricted = "1",
                        UserCreate = "thanhnq@gmail.com",
                        IsDelete = "0"

                    },

                    new Entities.Examination
                    {
                        Id = new Guid("b78c0f1d-60c3-4760-9241-c0fe443d02d5"),
                        Name = "Thi đố vui",
                        ShortDes = "Quiz đố vui nhằm giải trí sau giờ học căng thẳng",
                        Content = "Kì thi gồm các môn CNPM, thuật toán logic",
                        Duration = 20,
                        NumberOfQuestions = 10,
                        IsTimeRetricted = "1",
                        UserCreate = "thanhnq@gmail.com",
                        IsDelete = "0"

                    }
                );
                context.SaveChanges();

            }
        }
    }
}
