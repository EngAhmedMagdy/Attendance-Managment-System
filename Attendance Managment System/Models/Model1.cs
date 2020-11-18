namespace Attendance_Managment_System.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Leaving> Leavings { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .Property(e => e.attendState)
                .IsUnicode(false);

            modelBuilder.Entity<Attendance>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<Leaving>()
                .Property(e => e.LeaveRequest)
                .IsUnicode(false);

            modelBuilder.Entity<Leaving>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Passward)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Gender)
                .IsUnicode(false);
        }
    }
}
