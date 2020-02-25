using Microsoft.EntityFrameworkCore;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DAL
{
    public class StudentPortalDbContext : DbContext
    {
        public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options)
               : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

        }
        public virtual DbSet<Attendances> Attendances { get; set; }
        public virtual DbSet<Clearence> Clearence { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseTeacherMapping> CourseTeacherMapping { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<Parents> Parents { get; set; }
        public virtual DbSet<Routine> Routine { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentFeeTransaction> StudentFeeTransaction { get; set; }
        public virtual DbSet<StudentPayment> StudentPayment { get; set; }
        public virtual DbSet<StudentRegistration> StudentRegistration { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserMapping> UserMapping { get; set; }










        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Attendances>(entity =>
            {
                entity.HasKey(e => e.AttendanceId);
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.Cascade);

               


            });

            modelBuilder.Entity<Clearence>(entity =>
            {
                entity.HasKey(e => e.ClearenceId);
                entity.Property(e => e.StudentFeeTransactionId);
                entity.Property(e => e.StudentPaymentId);
                entity.Property(e => e.StudentId);


               
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

            });

            modelBuilder.Entity<CourseTeacherMapping>(entity =>
            {
                entity.HasKey(e => e.CourseTeacherMappingId);
                entity.HasOne(e => e.Semester)
              .WithMany(e => e.CourseTeacherMapping)
               .HasForeignKey(e => e.SemesterId)
              .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Course)
             .WithMany(e => e.CourseTeacherMapping)
              .HasForeignKey(e => e.CourseId)
             .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Teacher)
            .WithMany(e => e.CourseTeacherMapping)
             .HasForeignKey(e => e.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);



            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.HasKey(e => e.MarksId);


                entity.HasOne(e => e.Student)
                .WithMany(e => e.Marks)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(e => e.Semester)
                .WithMany(e => e.Marks)
                .HasForeignKey(e => e.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(e => e.CourseTeacherMapping)
                .WithMany(e => e.Marks)
                .HasForeignKey(e => e.CourseTeacherMappingId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.MarksType)
                .IsRequired()
                .HasMaxLength(30);


            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasKey(e => e.NoticeId);


            });


            modelBuilder.Entity<Parents>(entity =>
            {
                entity.HasKey(e => e.ParentsId);
                entity.HasOne(e => e.Student)
              .WithMany(e => e.Parent)
               .HasForeignKey(e => e.StudentId)
              .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.MobileNo)

                .IsRequired()
                .HasMaxLength(20);
            });


            modelBuilder.Entity<Routine>(entity =>
            {
                entity.HasKey(e => e.RoutineId);
                entity.Property(e => e.TeacherId);
                entity.Property(e => e.SemesterId);

                

            });



            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.SemesterId);
                entity.Property(e => e.SemesterName)
                .IsRequired()
                .HasMaxLength(30);


            });


            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

            

            });

            modelBuilder.Entity<StudentFeeTransaction>(entity =>
            {
                entity.HasKey(e => e.StudentFeeTransactionId);

                entity.HasOne(e => e.Student)
                .WithMany(e => e.StudentFeeTransaction)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.StudentRegistrationId);

              

            });

            modelBuilder.Entity<StudentPayment>(entity =>
            {
                entity.HasKey(e => e.StudentPaymentId);

                entity.HasOne(e => e.Student)
                .WithMany(e => e.StudentPayment)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.StudentFeeTransactionId);

               

            });


            modelBuilder.Entity<StudentRegistration>(entity =>
            {
                entity.HasKey(e => e.StudentRegistrationId);
                entity.HasOne(e => e.Student)
                .WithMany(e => e.StudentRegistration)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(e => e.Course)
                .WithMany(e => e.StudentRegistration)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.SemesterId);
                entity.Property(e => e.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(30)
                   .IsUnicode(false);


            });


            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId);
                entity.Property(e => e.TeacherCode);
                entity.Property(e => e.BloodGroup);
                entity.Property(e => e.Address);
                entity.Property(e => e.DateOfBirth);
                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);



            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                
                //entity.Property(e => e.CreatedDate);



                

            });

            modelBuilder.Entity<UserMapping>(entity =>
            {
                entity.HasKey(e => e.UserMappingId);

                //entity.HasIndex(e => e.UserId);
                //entity.HasOne(e => e.User)
                //.WithMany(e => e.UserMapping)
                //.HasForeignKey(e => e.UserId)
                //.OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
