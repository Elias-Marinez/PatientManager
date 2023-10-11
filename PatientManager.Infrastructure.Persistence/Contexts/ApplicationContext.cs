
using Microsoft.EntityFrameworkCore;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<LabReport> LabReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables & Primary Keys
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Doctor>()
                .ToTable("Doctors")
                .HasKey(d => d.DoctorId);

            modelBuilder.Entity<Patient>()
                .ToTable("Patients")
                .HasKey(p => p.PatientId);

            modelBuilder.Entity<LabTest>()
                .ToTable("LabTests")
                .HasKey(lt => lt.LabTestId);

            modelBuilder.Entity<Appointment>()
                .ToTable("Appointments")
                .HasKey(a => a.AppointmentId);

            modelBuilder.Entity<LabReport>()
                .ToTable("LabReports")
                .HasKey(lr => lr.LabReportId);
            #endregion

            #region "Relationships"

            modelBuilder.Entity<Patient>()
                .HasMany<Appointment>(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
                .HasMany<Appointment>(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LabTest>()
                .HasMany<LabReport>(lt => lt.LabReports)
                .WithOne(lr => lr.LabTest)
                .HasForeignKey(lr => lr.LabTestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasMany<LabReport>(a => a.LabReports)
                .WithOne(lr => lr.Appointment)
                .HasForeignKey(lr => lr.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configurations"

                #region Users
                modelBuilder.Entity<User>()
                    .Property(user => user.Name)
                    .HasMaxLength(30);

                modelBuilder.Entity<User>()
                    .Property(user => user.LastName)
                    .HasMaxLength(30);

                modelBuilder.Entity<User>()
                    .Property(user => user.Email)
                    .HasMaxLength(60);

                modelBuilder.Entity<User>()
                    .Property(user => user.Username)
                    .HasMaxLength(30);
                #endregion

                #region Patients
                modelBuilder.Entity<Patient>()
                    .Property(patient => patient.Name)
                    .HasMaxLength(30);

                modelBuilder.Entity<Patient>()
                    .Property(patient => patient.LastName)
                    .HasMaxLength(30);

                modelBuilder.Entity<Patient>()
                    .Property(e => e.Birtday)
                    .HasConversion(
                    dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime)
                );
                #endregion

                #region Doctors
                modelBuilder.Entity<Doctor>()
                    .Property(doctor => doctor.Name)
                    .HasMaxLength(30);

                modelBuilder.Entity<Doctor>()
                    .Property(doctor => doctor.LastName)
                    .HasMaxLength(30);
                #endregion

            #endregion
        }
    }
}
