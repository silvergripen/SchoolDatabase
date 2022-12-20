using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolDatabase.Models;

namespace SchoolDatabase.Data
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adress> Adresses { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<GradeSet> GradeSets { get; set; } = null!;
        public virtual DbSet<Personel> Personels { get; set; } = null!;
        public virtual DbSet<PersonelClass> PersonelClasses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentClass> StudentClasses { get; set; } = null!;
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Work> Works { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>(entity =>
            {
                entity.ToTable("Adress");

                entity.Property(e => e.Adress1)
                    .HasMaxLength(50)
                    .HasColumnName("Adress");

                entity.Property(e => e.County).HasMaxLength(50);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Classdate).HasColumnType("datetime");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Subjectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Classes_Subject");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Dateset).HasColumnType("date");

                entity.Property(e => e.Grade1).HasColumnName("Grade");

                entity.HasOne(d => d.Grade1Navigation)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.Grade1)
                    .HasConstraintName("FK_Grade_GradeSet");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.Studentid)
                    .HasConstraintName("FK_Grade_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.Subjectid)
                    .HasConstraintName("FK_Grade_Subject1");
            });

            modelBuilder.Entity<GradeSet>(entity =>
            {
                entity.ToTable("GradeSet");

                entity.Property(e => e.Grade)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.HasKey(e => e.Jobid);

                entity.ToTable("Personel");

                entity.Property(e => e.Bday).HasColumnType("date");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.Adressid)
                    .HasConstraintName("FK_Personel_Adress");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK_Personel_Work");
            });

            modelBuilder.Entity<PersonelClass>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.PersonelClasses)
                    .HasForeignKey(d => d.Classid)
                    .HasConstraintName("FK_PersonelClasses_Classes");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PersonelClass)
                    .HasForeignKey<PersonelClass>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonelClasses_Personel");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Bday).HasColumnType("date");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Adressid)
                    .HasConstraintName("FK_Student_Adress1");
            });

            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.ToTable("StudentClass");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_StudentClass_Classes");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentClasses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentClass_Student");
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.ToTable("StudentSubject");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.Studentid)
                    .HasConstraintName("FK_StudentSubject_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.Subjectid)
                    .HasConstraintName("FK_StudentSubject_Subjects");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .HasColumnName("Subject_name");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("Work");

                entity.Property(e => e.Work1)
                    .HasMaxLength(50)
                    .HasColumnName("Work");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
