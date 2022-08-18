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
                        Id_Question_Bank = new Guid("c00bce49-1899-45b6-9f17-b104b52a7889"),
                        Content = "Kích thước của kiểu Decimal là ?",
                        Level = "1",
                        Type = "Lập trình C#",
                        Explaint = "kiểu dữ liệu demical",
                        IsDelete = "0",
                        ImageUrl = ""
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Id_Question_Bank = new Guid("c00bce49-1899-45b6-9f17-b104b52a7889"),
                        Content = "Mô hình MVC, đâu là tầng tương tác với user ?",
                        Level = "0",
                        Type = "Lập trình Asp.net",
                        Explaint = "Search mô hình MVC",
                        IsDelete = "0",
                        ImageUrl = ""
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Id_Question_Bank = new Guid("5e25eaa8-569b-412b-af15-652e6adf8bf5"),
                        Content = "25*4 = ",
                        Level = "0",
                        Type = "Toán logic",
                        Explaint = "Bấm máy đi",
                        IsDelete = "0",
                        ImageUrl = ""
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Id_Question_Bank = new Guid("55ec968f-4971-487a-92cc-3452938610c7"),
                        Content = "Thời gian Intern vào Rikkei là ?",
                        Level = "0",
                        Type = "Kiến thức chung",
                        Explaint = "Có thể nghiên cứu trên mạng",
                        IsDelete = "0",
                        ImageUrl = ""
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Id_Question_Bank = new Guid("65884b6a-a20f-4884-b742-616e13072d6d"),
                        Content = "AAAA+ AAXX = ",
                        Level = "0",
                        Type = "Di truyền gen",
                        Explaint = "Sinh học",
                        IsDelete = "0",
                        ImageUrl = ""
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Id_Question_Bank = new Guid("5e25eaa8-569b-412b-af15-652e6adf8bf5"),
                        Content = "1594*22 = ",
                        Level = "0",
                        Type = "Toán logic",
                        Explaint = "Có thể nghiên cứu trên mạng",
                        IsDelete = "0",
                        ImageUrl = ""
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Id_Question_Bank = new Guid("55ec968f-4971-487a-92cc-3452938610c7"),
                        Content = "Bao lâu bán được 1 tỉ gói mè = ",
                        Level = "0",
                        Type = "Toán logic",
                        Explaint = "1 gói mè ~ 1$",
                        IsDelete = "0",
                        ImageUrl = ""
                    },

                    new Entities.Question
                    {
                        Id = Guid.NewGuid(),
                        Id_Question_Bank = new Guid("30a80941-7acb-421e-9504-3f2d6c1cccca"),
                        Content = "Công thức trọng lực? ",
                        Level = "0",
                        Type = "Vật lý đại cương ",
                        Explaint = "Bấm máy",
                        IsDelete = "0",
                        ImageUrl = ""
                    }
                );
                context.SaveChanges();

            }
        }
    }
}