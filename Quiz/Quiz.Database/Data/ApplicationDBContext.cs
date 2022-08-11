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
        public DbSet<Exam_History> Exam_Historys { get; set; }
        public DbSet<Exam_History_Detail> Exam_History_Details { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //cau hinh table Examination_Detail
            modelBuilder.Entity<Examination_Detail>().HasKey(c => new { c.Id_Exam, c.Id_Question_Bank});
            modelBuilder.Entity<Examination>()
                .HasMany(p => p.Examination_Details)
                .WithOne(p => p.Examination)
                .HasForeignKey(c => c.Id_Exam);

            modelBuilder.Entity<Answer>().HasKey(c => new { c.SEQ, c.ID_Question });
            



            //cau hinh table Exam_History
            modelBuilder.Entity<Exam_History>().HasKey(c => new { c.ID_Exam, c.Email_User, c.DateDoExam });
            modelBuilder.Entity<Exam_History>()
                .HasOne(p => p.Accounts)
                .WithMany(p => p.Exam_Historys)
                .HasForeignKey(c => c.Email_User);
            modelBuilder.Entity<Exam_History>()
                .HasOne(p => p.Examinations)
                .WithMany(p => p.Exam_Historys)
                .HasForeignKey(c => c.ID_Exam);

            //cau hinh table Exam_History_Detail - TABLE Exam History
            modelBuilder.Entity<Exam_History_Detail>().HasKey(c => new { c.ID_Exam, c.Email_User, c.Date_Do_Exam, c.ID_Question });
            modelBuilder.Entity<Exam_History>()
                .HasMany(p => p.Exam_History_Details)
                .WithOne(p => p.Exam_History)
                .HasForeignKey(c => new {c.ID_Exam, c.Email_User, c.Date_Do_Exam});
                
                
     
                
        }
    }
}
