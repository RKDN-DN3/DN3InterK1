using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz.Entities;

namespace Quiz.Database.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Examination> Examinations { get; set; }
    }
}
