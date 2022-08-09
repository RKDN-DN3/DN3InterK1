using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;

namespace Quiz.Web.Models
{
    public class SeedData_Question
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDBContext>>()))
            {
                if (context.Questions.Any())
                {
                    return;
                }

                context.Questions.AddRange(
                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Content = "Kích thước của kiểu Decimal là ?",
                        Level = "1",
                        Type = "Lập trình C#",
                        Explaint = "Có thể nghiên cứu trên mạng",
                        IsDelete = "0",
                        ImageUrl = ""
                        //CreateDate = DateTime.Now,
                        //Id = Guid.NewGuid(),
                        //UserCreate = Guid.NewGuid()
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Content = "Mô hình MVC, đâu là tầng tương tác với user ?",
                        Level = "0",
                        Type = "Lập trình Asp.net",
                        Explaint = "Có thể nghiên cứu trên mạng",
                        IsDelete = "0",
                        ImageUrl = ""
                        //CreateDate = DateTime.Now,
                        //Id = Guid.NewGuid(),
                        //UserCreate = Guid.NewGuid()
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Content = "25*4 = ",
                        Level = "0",
                        Type = "Toán logic",
                        Explaint = "Có thể nghiên cứu trên mạng",
                        IsDelete = "0",
                        ImageUrl = ""
                        //CreateDate = DateTime.Now,
                        //Id = Guid.NewGuid(),
                        //UserCreate = Guid.NewGuid()
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Content = "Thời gian Intern vào Rikkei là ?",
                        Level = "0",
                        Type = "Kiến thức chung",
                        Explaint = "Có thể nghiên cứu trên mạng",
                        IsDelete = "0",
                        ImageUrl = ""
                        //Id_ = Guid.NewGuid()
                        //CreateDate = DateTime.Now,
                        //Id = Guid.NewGuid(),
                        //UserCreate = Guid.NewGuid()
                    }
                );
                context.SaveChanges();

            }
        }
    }
}
