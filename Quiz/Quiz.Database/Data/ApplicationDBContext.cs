﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

            //Cau hinh mapping Table Examination_Detail - Table Examination
            modelBuilder.Entity<Examination_Detail>().HasKey(c => new { c.Id_Exam, c.Id_Question_Bank});
            modelBuilder.Entity<Examination>()
                .HasMany(p => p.Examination_Details)
                .WithOne(p => p.Examination)
                .HasForeignKey(c => c.Id_Exam);

            //Cau hinh mapping Table Answer - Table Question
            modelBuilder.Entity<Answer>().HasKey(c => new { c.SEQ, c.Id_Question });
            modelBuilder.Entity<Question>()
                .HasMany(p => p.Answers)
                .WithOne(p => p.Question)
                .HasForeignKey(c => c.Id_Question);

            //Cau hinh Table List_Question_In_Exam
            modelBuilder.Entity<List_Question_In_Exam>().HasKey(c => new { c.Id_Exam, c.Id_Question});

            modelBuilder.Entity<List_Question_In_Exam>()
                .HasOne(p => p.Examination)
                .WithMany(p => p.List_Question_In_Exams)
                .HasForeignKey(p => p.Id_Exam);

            modelBuilder.Entity<List_Question_In_Exam>()
                .HasOne(p => p.Question)
                .WithMany(p => p.List_Question_In_Exams)
                .HasForeignKey(p => p.Id_Question);

            //Cau hinh Table Question
            modelBuilder.Entity<Question_Bank>()
                .HasMany(p => p.Questions)
                .WithOne(p => p.Question_Bank)
                .HasForeignKey(c => c.Id_Question_Bank);
        }
    }
}
