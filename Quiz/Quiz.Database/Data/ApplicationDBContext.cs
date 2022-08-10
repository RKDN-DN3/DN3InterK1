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
        public DbSet<Question_Bank> Question_Banks { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Examination_Detail> Examination_Details{ get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Examination_Detail>().HasKey(c => new { c.Id_Exam, c.Id_Question_Bank});
            modelBuilder.Entity<Examination>()
                .HasMany(p => p.Examination_Details)
                .WithOne(p => p.Examination)
                .HasForeignKey(c => c.Id_Exam);

            modelBuilder.Entity<Answer>().HasKey(c => new { c.SEQ, c.ID_Question });
        }
    }
}
