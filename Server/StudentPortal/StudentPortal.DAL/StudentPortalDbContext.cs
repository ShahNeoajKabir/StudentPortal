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
            //    modelBuilder.Entity<User>(entity =>
            //    {
            //        entity.HasKey(e => e.AccountNo);

            //        entity.HasIndex(e => e.AccountDetailId);

            //        entity.Property(e => e.AccountNo).ValueGeneratedNever();

            //        entity.Property(e => e.AccountDetailId).HasColumnName("AccountDetailID");

            //        entity.HasOne(d => d.AccountDetail)
            //            .WithOne(p => p.Account);
            //    });

            //    modelBuilder.Entity<AccountDetail>(entity =>
            //    {

            //        entity.HasIndex(e => e.PermanentAddressId);

            //        entity.HasIndex(e => e.PresentAddressId);

            //        entity.Property(e => e.AccountDetailId).HasColumnName("AccountDetailID");


            //        entity.Property(e => e.IdentityNo).HasColumnName("NID");

            //        entity.Property(e => e.PermanentAddressId).HasColumnName("PermanentAddressID");

            //        entity.Property(e => e.PresentAddressId).HasColumnName("PresentAddressID");

            //        entity.HasOne(d => d.PermanentAddress)
            //            .WithMany(p => p.AccountDetailPermanentAddress)
            //            .HasForeignKey(d => d.PermanentAddressId);

            //        entity.HasOne(d => d.PresentAddress)
            //            .WithMany(p => p.AccountDetailPresentAddress)
            //            .HasForeignKey(d => d.PresentAddressId);
            //    });

            //    modelBuilder.Entity<Address>(entity =>
            //    {
            //        entity.Property(e => e.AddressId).HasColumnName("AddressID");

            //        entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

            //    });

            //    modelBuilder.Entity<AudiLog>(entity =>
            //    {
            //        entity.HasKey(e => e.AuditLogId);

            //        entity.Property(e => e.ActionId).HasColumnName("ActionID");

            //        entity.Property(e => e.LogDateTimeUtc).HasColumnName("LogDateTimeUTC");

            //        entity.Property(e => e.LogTypeId).HasColumnName("LogTypeID");

            //        entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            //        entity.Property(e => e.SessionId).HasColumnName("SessionID");

            //        entity.Property(e => e.UserId).HasColumnName("UserID");
            //    });

            //    modelBuilder.Entity<ZoneDetail>(entity =>
            //    {
            //        entity.HasKey(e => e.ZoneId);

            //        entity.Property(e => e.ZoneId).HasColumnName("ZoneID");
            //    });

            //    modelBuilder.Entity<Vendor>(entity =>
            //    {
            //        entity.HasKey(e => e.VendorId);

            //        entity.Property(e => e.VendorId).HasColumnName("VendorID");
            //    });

            //    modelBuilder.Entity<SalesForceReport>(entity =>
            //    {
            //        entity.HasKey(e => e.SalesForceReportId);

            //        entity.Property(e => e.SalesForceReportId).HasColumnName("SalesForceReportID");
            //    });


            //    modelBuilder.Entity<PumpDetail>(entity =>
            //    {
            //        entity.HasKey(e => e.PumpId);

            //        entity.Property(e => e.PumpId).HasColumnName("BoothID");

            //        entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

            //        entity.Property(e => e.VendorId).HasColumnName("VendorID");

            //        entity.HasOne(d => d.Zone)
            //            .WithMany(p => p.Pump)
            //            .HasForeignKey(d => d.ZoneId);
            //        entity.Ignore(x => x.NumberOfDevices);

            //        entity.HasOne(d => d.Vendor)
            //           .WithMany(p => p.Pump)
            //           .HasForeignKey(d => d.VendorId);
            //        entity.Ignore(c => c.Balance);
            //        entity.Ignore(c => c.VendorName);
            //        entity.Ignore(c => c.ZoneName);


            //    });

            //    modelBuilder.Entity<CardDetail>(entity =>
            //    {
            //        entity.HasKey(e => e.CardNumber);

            //        entity.HasIndex(e => e.AccountNo);

            //        entity.HasIndex(e => e.RefCardNumber);

            //        entity.Property(e => e.CardNumber).ValueGeneratedNever();

            //        entity.HasOne(d => d.AccountNoNavigation)
            //            .WithMany(p => p.CardDetail)
            //            .HasForeignKey(d => d.AccountNo);

            //        entity.HasOne(d => d.RefCardNumberNavigation)
            //            .WithMany(p => p.InverseRefCardNumberNavigation)
            //            .HasForeignKey(d => d.RefCardNumber);
            //    });

            modelBuilder.Entity<Attendances>(entity =>
            {
                entity.HasKey(e => e.AttendanceId);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.StudentId);
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

                entity.HasOne(e => e.Course)
                .WithMany(e => e.CourseTeacherMapping)
                .HasForeignKey(e => e.CourseId);

                entity.HasOne(e => e.Teacher)
                .WithMany(e => e.CourseTeacherMapping)
                .HasForeignKey(e => e.TeacherId);

                entity.HasOne(e => e.Semester)
                .WithMany(e => e.CourseTeacherMapping)
                .HasForeignKey(e => e.SemesterId);

            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.HasKey(e => e.MarksId);

                entity.HasOne(e => e.Student)
                .WithMany(e => e.Marks)
                .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Semester)
                .WithMany(e => e.Marks)
                .HasForeignKey(e => e.SemesterId);

                entity.HasOne(e => e.CourseTeacherMapping)
                .WithMany(e => e.Marks)
                .HasForeignKey(e => e.CourseTeacherMapping);

            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasKey(e => e.NoticeId);

            });


            modelBuilder.Entity<Parents>(entity =>
            {
                entity.HasKey(e => e.ParentsId);

                entity.Property(e => e.StudentId);
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
                .HasForeignKey(e => e.StudentId);

                entity.Property(e => e.StudentRegistrationId);

            });

            modelBuilder.Entity<StudentPayment>(entity =>
            {
                entity.HasKey(e => e.StudentPaymentId);

                entity.HasOne(e => e.Student)
                .WithMany(e => e.StudentPayment)
                .HasForeignKey(e => e.StudentId);

                entity.Property(e => e.StudentFeeTransactionId);

            });

            modelBuilder.Entity<StudentRegistration>(entity =>
            {
                entity.HasKey(e => e.StudentRegistrationId);

                entity.HasOne(e => e.Student)
                .WithMany(e => e.StudentRegistration)
                .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                .WithMany(e => e.StudentRegistration)
                .HasForeignKey(e => e.CourseId);

                entity.Property(e => e.SemesterId);

            });


            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId);
                entity.Property(e => e.TeacherCode);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserTypeId);

            });

            modelBuilder.Entity<UserMapping>(entity =>
            {
                entity.HasKey(e => e.UserMappingId);

                entity.HasOne(e => e.User)
                .WithMany(e => e.UserMapping)
                .HasForeignKey(e => e.UserId);
                entity.Property(e => e.IdentityId);

            });
        }
    }
}
