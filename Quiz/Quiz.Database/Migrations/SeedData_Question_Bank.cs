using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Database.Data;
using Quiz.Entities;


namespace Quiz.Database.Migrations
{
    public class SeedData_Question_Bank
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDBContext>>()))
            {
                if (context.Question_Banks.Any())
                {
                    return;
                }

                context.Question_Banks.AddRange(
                    new Entities.Question_Bank
                    {
                        Id = new Guid("5e25eaa8-569b-412b-af15-652e6adf8bf5"),
                        Name = "Bo cau hoi Toan hoc",
                        IsDelete = "0"
                    },

                    new Entities.Question_Bank
                    {
                        Id = new Guid("30a80941-7acb-421e-9504-3f2d6c1cccca"),
                        Name = "Bo cau hoi VatLy",
                        IsDelete = "0"
                    },

                    new Entities.Question_Bank
                    {
                        Id = new Guid("55ec968f-4971-487a-92cc-3452938610c7"),
                        Name = "Bo cau hoi Logic",
                        IsDelete = "0"
                    },

                    new Entities.Question_Bank
                    {
                        Id = new Guid("65884b6a-a20f-4884-b742-616e13072d6d"),
                        Name = "Bo cau hoi Sinh hoc",
                        IsDelete = "0"
                    },
                    new Entities.Question_Bank
                    {
                        Id = new Guid("c00bce49-1899-45b6-9f17-b104b52a7889"),
                        Name = "Bo cau hoi IT",
                        IsDelete = "0"
                    }
                );
                context.SaveChanges();

            }
        }
    }
}
