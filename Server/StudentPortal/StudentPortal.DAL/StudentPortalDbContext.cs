using Microsoft.EntityFrameworkCore;
using StudentPortal.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.DAL
{
    class StudentPortalDbContext: DbContext
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




        //public virtual DbSet<Account> Account { get; set; }
        //public virtual DbSet<AccountDetail> AccountDetail { get; set; }
        //public virtual DbSet<Address> Address { get; set; }
        //public virtual DbSet<AudiLog> AudiLog { get; set; }
        //public virtual DbSet<DashboardLog> DashboardLog { get; set; }
        //public virtual DbSet<DeviceLog> DeviceLog { get; set; }
        //public virtual DbSet<ZoneDetail> ZoneDetail { get; set; }
        //public virtual DbSet<PumpDetail> PumpDetail { get; set; }
        //public virtual DbSet<CardDetail> CardDetail { get; set; }
        //public virtual DbSet<ATMDetail> ATMDetail { get; set; }
        //public virtual DbSet<RechargeDetail> RechargeDetail { get; set; }
        //public virtual DbSet<Transaction> Transaction { get; set; }
        //public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<UserType> UserType { get; set; }
        //public virtual DbSet<WaterCostSetting> WaterCostSetting { get; set; }
        //public virtual DbSet<WaterTransactionDetail> WaterTransactionDetail { get; set; }
        //public virtual DbSet<Vendor> Vendor { get; set; }
        //public virtual DbSet<SalesForceReport> SalesForceReport { get; set; }
        //public virtual DbSet<BkashLog> BkashLog { get; set; }
        //public virtual DbSet<BkashTransaction> BkashTransaction { get; set; }
        //public virtual DbSet<WasaRechargeRequest> WasaRechargeRequest { get; set; }
        //public virtual DbSet<ATMUpdateHistory> ATMUpdateHistory { get; set; }
        //public virtual DbSet<ExceptionLog> ExceptionLog { get; set; }
        //public virtual DbSet<WorkerResponse> WorkerResponse { get; set; }
        //public virtual DbSet<DeviceLogDispanse> DeviceLogDispanse { get; set; }




        //public virtual DbSet<PumpRechargeTransactionDetails> PumpRechargeTransactionDetails { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.AccountNo);

                entity.HasIndex(e => e.AccountDetailId);

                entity.Property(e => e.AccountNo).ValueGeneratedNever();

                entity.Property(e => e.AccountDetailId).HasColumnName("AccountDetailID");

                entity.HasOne(d => d.AccountDetail)
                    .WithOne(p => p.Account);
            });

            modelBuilder.Entity<AccountDetail>(entity =>
            {

                entity.HasIndex(e => e.PermanentAddressId);

                entity.HasIndex(e => e.PresentAddressId);

                entity.Property(e => e.AccountDetailId).HasColumnName("AccountDetailID");


                entity.Property(e => e.IdentityNo).HasColumnName("NID");

                entity.Property(e => e.PermanentAddressId).HasColumnName("PermanentAddressID");

                entity.Property(e => e.PresentAddressId).HasColumnName("PresentAddressID");

                entity.HasOne(d => d.PermanentAddress)
                    .WithMany(p => p.AccountDetailPermanentAddress)
                    .HasForeignKey(d => d.PermanentAddressId);

                entity.HasOne(d => d.PresentAddress)
                    .WithMany(p => p.AccountDetailPresentAddress)
                    .HasForeignKey(d => d.PresentAddressId);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

            });

            modelBuilder.Entity<AudiLog>(entity =>
            {
                entity.HasKey(e => e.AuditLogId);

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.LogDateTimeUtc).HasColumnName("LogDateTimeUTC");

                entity.Property(e => e.LogTypeId).HasColumnName("LogTypeID");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ZoneDetail>(entity =>
            {
                entity.HasKey(e => e.ZoneId);

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.VendorId);

                entity.Property(e => e.VendorId).HasColumnName("VendorID");
            });

            modelBuilder.Entity<SalesForceReport>(entity =>
            {
                entity.HasKey(e => e.SalesForceReportId);

                entity.Property(e => e.SalesForceReportId).HasColumnName("SalesForceReportID");
            });


            modelBuilder.Entity<PumpDetail>(entity =>
            {
                entity.HasKey(e => e.PumpId);

                entity.Property(e => e.PumpId).HasColumnName("BoothID");

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Pump)
                    .HasForeignKey(d => d.ZoneId);
                entity.Ignore(x => x.NumberOfDevices);

                entity.HasOne(d => d.Vendor)
                   .WithMany(p => p.Pump)
                   .HasForeignKey(d => d.VendorId);
                entity.Ignore(c => c.Balance);
                entity.Ignore(c => c.VendorName);
                entity.Ignore(c => c.ZoneName);


            });

            modelBuilder.Entity<CardDetail>(entity =>
            {
                entity.HasKey(e => e.CardNumber);

                entity.HasIndex(e => e.AccountNo);

                entity.HasIndex(e => e.RefCardNumber);

                entity.Property(e => e.CardNumber).ValueGeneratedNever();

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.CardDetail)
                    .HasForeignKey(d => d.AccountNo);

                entity.HasOne(d => d.RefCardNumberNavigation)
                    .WithMany(p => p.InverseRefCardNumberNavigation)
                    .HasForeignKey(d => d.RefCardNumber);
            });

            modelBuilder.Entity<RechargeDetail>(entity =>
            {
                entity.HasKey(e => e.RechargeDetailId);

                entity.HasOne(d => d.PumpAccount)
                    .WithMany(p => p.RechargeDetail)
                    .HasForeignKey(d => d.PumpAccountId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.HasOne(d => d.Pump)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PumpId);
                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.User)
                    .HasForeignKey(q => q.ZoneId);

                entity.Ignore(x => x.UserTypeName);
            });

            modelBuilder.Entity<ATMDetail>(entity =>
            {
                entity.HasKey(e => e.Serial);

                entity.HasIndex(e => e.PumpId);

                entity.Property(e => e.Serial).HasColumnName("ATMSerial");

                entity.Property(e => e.PumpId).HasColumnName("BoothID");

                entity.HasOne(d => d.Pump)
                    .WithMany(p => p.ATM)
                    .HasForeignKey(d => d.PumpId);
            });

            modelBuilder.Entity<RechargeDetail>(entity =>
            {
                entity.HasIndex(e => e.CardNumber);

                entity.HasIndex(e => e.TransactionId);

                entity.Property(e => e.RechargeDetailId).HasColumnName("RechargeDetailID");

                entity.HasOne(d => d.CardNumberNavigation)
                    .WithMany(p => p.RechargeDetail)
                    .HasForeignKey(d => d.CardNumber);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.RechargeDetail)
                    .HasForeignKey(d => d.TransactionId);
            });


            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Trid);

                entity.HasIndex(e => e.AccountNo);

                entity.Property(e => e.Trid).HasColumnName("TRID");

                entity.Property(e => e.Trtype).HasColumnName("TRType");

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.AccountNo);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.HasIndex(e => e.UserTypeId);

                entity.Property(e => e.UserName).ValueGeneratedNever();

                entity.Property(e => e.Macaddress).HasColumnName("MACAddress");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId);
            });

            modelBuilder.Entity<DashboardLog>(entity =>
            {
                entity.HasKey(e => e.DashboardLogID);
                entity.Property(e => e.DashboardLogID).HasColumnName("DashboardLogID");

                entity.Property(e => e.UserName).HasColumnName("UserName");
                entity.HasOne(d => d.User)
                    .WithMany(p => p.DashboardLog)
                    .HasForeignKey(d => d.UserName);
            });

            modelBuilder.Entity<WaterCostSetting>(entity =>
            {
                entity.HasKey(e => e.Wcsid);

                entity.Property(e => e.Wcsid).HasColumnName("WCSID");
            });

            modelBuilder.Entity<WaterTransactionDetail>(entity =>
            {
                entity.HasKey(e => e.Wtid);

                entity.HasIndex(e => e.AccountNo);

                entity.HasIndex(e => e.ATMSerial);

                entity.HasIndex(e => e.TransactionId);

                entity.Property(e => e.Wtid).HasColumnName("WTID");

                entity.Property(e => e.ATMSerial).HasColumnName("ATMSerial");
                entity.Property(e => e.PumpId).HasColumnName("PumpID");


                entity.Property(e => e.TrdateEnd).HasColumnName("TRDateEnd");

                entity.Property(e => e.TrdateStart).HasColumnName("TRDateStart");

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.WaterTransactionDetail)
                    .HasForeignKey(d => d.AccountNo);

                entity.HasOne(d => d.ATM)
                    .WithMany(p => p.WaterTransactionDetail)
                    .HasForeignKey(d => d.ATMSerial);

                entity.HasOne(d => d.Pump)
                    .WithMany(p => p.WaterTransactionDetail)
                    .HasForeignKey(d => d.PumpId);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.WaterTransactionDetail)
                    .HasForeignKey(d => d.TransactionId);
            });

            modelBuilder.Entity<ATMUpdateHistory>(entity =>
            {
                entity.HasKey(e => e.ATMUpdateHistoryId);
                entity.Property(e => e.ATMUpdateHistoryId).HasColumnName("ATMUpdateHistoryID");

                entity.Property(e => e.ATMId).HasColumnName("ATMID");
                entity.Property(e => e.PumpId).HasColumnName("PumpID");

                //entity.HasOne(d => d.ATMDetail)
                //    .WithMany(p =>p.ATMUpdateHistory)
                //    .HasForeignKey(d => d.ATMId);

                //entity.HasOne(d => d.PumpDetail)
                //    .WithMany(p => p.ATMUpdateHistory)
                //    .HasForeignKey(d => d.PumpId);

            });

            modelBuilder.Entity<BkashLog>(entity =>
            {
                entity.HasKey(e => e.LogId);
            });

            modelBuilder.Entity<BkashTransaction>(entity =>
            {
                entity.HasKey(e => e.TRID);
            });
            modelBuilder.Entity<WasaRechargeRequest>(entity =>
            {
                entity.HasKey(e => e.WasaRechargeRequestId);

                entity.Property(e => e.WasaRechargeRequestId).HasColumnName("WasaRechargeRequestID");
            });
            modelBuilder.Entity<DeviceLog>(entity =>
            {
                entity.HasKey(e => e.DeviceLogID);

                entity.Property(e => e.DeviceLogID).HasColumnName("DeviceLogID");
            });
            //modelBuilder.Entity<DeviceLogDispanse>(entity =>
            //{
            //    entity.HasKey(e => e.DeviceLogID);

            //    entity.Property(e => e.DeviceLogID).HasColumnName("DeviceLogID");
            //});

            modelBuilder.Entity<ExceptionLog>(entity =>
            {
                entity.HasKey(e => e.ExceptionLogID);

                entity.Property(e => e.ExceptionLogID).HasColumnName("ExceptionLogID");
            });
            modelBuilder.Entity<WorkerResponse>(entity =>
            {
                entity.HasKey(e => e.WorkerResponseID);

                entity.Property(e => e.WorkerResponseID).HasColumnName("WorkerResponseID");
            });

            modelBuilder.Entity<PumpRechargeTransactionDetails>(entity =>
            {
                entity.HasKey(e => e.PumpRechargeTransactionDetailsId);

                entity.Property(e => e.PumpRechargeTransactionDetailsId).HasColumnName("PumpRechargeTransactionDetailsID");
                entity.Property(e => e.PumpId).HasColumnName("PumpID");


                entity.HasOne(d => d.pumpDetail)
                    .WithMany(p => p.pumpRechargeTransactionDetails)
                    .HasForeignKey(d => d.PumpId);

            });
        }
    }
}
