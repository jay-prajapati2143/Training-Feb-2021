﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StackOverFlowApi.Models.Authentication;

#nullable disable

namespace StackOverFlowApi.Models
{
    public partial class TempStackOverFlowContext : IdentityDbContext<ApplicationUser>
    {
        public TempStackOverFlowContext()
        {
        }

        public TempStackOverFlowContext(DbContextOptions<TempStackOverFlowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<BadgesEarnedByUser> BadgesEarnedByUsers { get; set; }
        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<CompaniesToExclude> CompaniesToExcludes { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<IndustriesToExclude> IndustriesToExcludes { get; set; }
        public virtual DbSet<JobProfile> JobProfiles { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TechPreferNotToWorkWith> TechPreferNotToWorkWiths { get; set; }
        public virtual DbSet<TechWantToWorkWith> TechWantToWorkWiths { get; set; }
        public virtual DbSet<TechnologiesUsedAsStudent> TechnologiesUsedAsStudents { get; set; }
        public virtual DbSet<TechnologiesUsedByUserInJob> TechnologiesUsedByUserInJobs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VwBadgesDetail> VwBadgesDetails { get; set; }
        public virtual DbSet<VwQuestionDetail> VwQuestionDetails { get; set; }
        public virtual DbSet<VwUserQadaetail> VwUserQadaetails { get; set; }
        public virtual DbSet<WhereUserLikeToWork> WhereUserLikeToWorks { get; set; }
        public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-AKRFK039\\SQLEXPRESS; Database=TempStackOverFlow; Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.Answer1).HasColumnName("Answer");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Answers__Questio__65370702");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_UserIDAnswers");
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.Property(e => e.BadgeId).HasColumnName("BadgeID");

                entity.Property(e => e.BadgeCategory).HasMaxLength(30);

                entity.Property(e => e.BadgeDescription).HasMaxLength(200);

                entity.Property(e => e.BadgeName).HasMaxLength(30);

                entity.Property(e => e.BadgeType).HasMaxLength(20);
            });

            modelBuilder.Entity<BadgesEarnedByUser>(entity =>
            {
                entity.ToTable("BadgesEarnedByUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BadgeId).HasColumnName("BadgeID");

                entity.Property(e => e.DateOfEarned).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Badge)
                    .WithMany(p => p.BadgesEarnedByUsers)
                    .HasForeignKey(d => d.BadgeId)
                    .HasConstraintName("Fk_BadgeIDBadge");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BadgesEarnedByUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_UserIDBadge");
            });

            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Bookmarks)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Bookmarks__Quest__5F7E2DAC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookmarks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bookmarks__UserI__5E8A0973");
            });

            modelBuilder.Entity<CompaniesToExclude>(entity =>
            {
                entity.ToTable("CompaniesToExclude");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyToExclude).HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompaniesToExcludes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Companies__UserI__7755B73D");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Degree).HasMaxLength(30);

                entity.Property(e => e.Summary).HasMaxLength(200);

                entity.Property(e => e.University).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_UserIDEducation");
            });

            modelBuilder.Entity<IndustriesToExclude>(entity =>
            {
                entity.ToTable("IndustriesToExclude");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IndustryToExclude).HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IndustriesToExcludes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Industrie__UserI__6BE40491");
            });

            modelBuilder.Entity<JobProfile>(entity =>
            {
                entity.ToTable("JobProfile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Industry).HasMaxLength(30);

                entity.Property(e => e.JobSearchStatus).HasMaxLength(50);

                entity.Property(e => e.JobType).HasMaxLength(30);

                entity.Property(e => e.MinAnnualSalary).HasColumnType("money");

                entity.Property(e => e.Role).HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobProfiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__JobProfil__UserI__690797E6");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Question1)
                    .HasMaxLength(500)
                    .HasColumnName("Question");

                entity.Property(e => e.TimeOfAsk).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_UserIDQuestion");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.TagName).HasMaxLength(30);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Tags__QuestionID__625A9A57");
            });

            modelBuilder.Entity<TechPreferNotToWorkWith>(entity =>
            {
                entity.ToTable("TechPreferNotToWorkWith");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TechPeferNotToWorkWith).HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TechPreferNotToWorkWiths)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__TechPrefe__UserI__6EC0713C");
            });

            modelBuilder.Entity<TechWantToWorkWith>(entity =>
            {
                entity.ToTable("TechWantToWorkWith");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TechYouWantToWorkWith).HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TechWantToWorkWiths)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__TechWantT__UserI__719CDDE7");
            });

            modelBuilder.Entity<TechnologiesUsedAsStudent>(entity =>
            {
                entity.ToTable("TechnologiesUsedAsStudent");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Technology).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TechnologiesUsedAsStudents)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_UserIDTech");
            });

            modelBuilder.Entity<TechnologiesUsedByUserInJob>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TechnologiesUsedByUserInJob");

                entity.Property(e => e.Technologies).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_UserIDTechInJob");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailId, "UQ__Users__7ED91AEEC51ED829")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AboutUser).HasMaxLength(200);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EmailID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.GitHub).HasMaxLength(100);

                entity.Property(e => e.LastSeen).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(20);

                entity.Property(e => e.Twitter).HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<VwBadgesDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwBadgesDetails");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<VwQuestionDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwQuestionDetails");

                entity.Property(e => e.Question).HasMaxLength(500);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            });

            modelBuilder.Entity<VwUserQadaetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwUserQADaetails");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<WhereUserLikeToWork>(entity =>
            {
                entity.ToTable("WhereUserLikeToWork");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location).HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WhereUserLikeToWorks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__WhereUser__UserI__74794A92");
            });

            modelBuilder.Entity<WorkExperience>(entity =>
            {
                entity.ToTable("WorkExperience");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName).HasMaxLength(30);

                entity.Property(e => e.JobTitle).HasMaxLength(30);

                entity.Property(e => e.Responsibilities).HasMaxLength(200);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkExperiences)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_UserIDWork");
            });

            
        }

        
    }
}