using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoctorFinder.EDM
{
    public partial class DoctorFinderDBContext : DbContext
    {
        public DoctorFinderDBContext()
        {
        }

        public DoctorFinderDBContext(DbContextOptions<DoctorFinderDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAdmin> TblAdmins { get; set; }
        public virtual DbSet<TblAppointment> TblAppointments { get; set; }
        public virtual DbSet<TblCity> TblCities { get; set; }
        public virtual DbSet<TblDoctor> TblDoctors { get; set; }
        public virtual DbSet<TblHospital> TblHospitals { get; set; }
        public virtual DbSet<TblPatient> TblPatients { get; set; }
        public virtual DbSet<TblState> TblStates { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-H46MKG7;Database=DoctorFinderDB; Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("tbl_Admin");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.AdminEmail)
                    .HasMaxLength(20)
                    .HasColumnName("Admin_Email");

                entity.Property(e => e.AdminFname)
                    .HasMaxLength(20)
                    .HasColumnName("Admin_Fname");

                entity.Property(e => e.AdminLname)
                    .HasMaxLength(20)
                    .HasColumnName("Admin_Lname");

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(30)
                    .HasColumnName("Admin_Password");

                entity.Property(e => e.AdminRole)
                    .HasMaxLength(30)
                    .HasColumnName("Admin_Role");
            });

            modelBuilder.Entity<TblAppointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);

                entity.ToTable("tbl_Appointment");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Appointment_Date");

                entity.Property(e => e.AppointmentPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Appointment_Price");

                entity.Property(e => e.AppointmentStatus).HasColumnName("Appointment_Status");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.TblAppointments)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_AppointmentDoctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblAppointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Appointment_Patient");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("tbl_City");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .HasColumnName("City_Name");

                entity.Property(e => e.PostCode).HasColumnName("Post_Code");
            });

            modelBuilder.Entity<TblDoctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("tbl_Doctor");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.DoctorAddressLine1)
                    .HasMaxLength(50)
                    .HasColumnName("Doctor_AddressLine1");

                entity.Property(e => e.DoctorAddressLine2)
                    .HasMaxLength(50)
                    .HasColumnName("Doctor_AddressLine2");

                entity.Property(e => e.DoctorAddressLine3)
                    .HasMaxLength(50)
                    .HasColumnName("Doctor_AddressLine3");

                entity.Property(e => e.DoctorEmail)
                    .HasMaxLength(20)
                    .HasColumnName("Doctor_Email");

                entity.Property(e => e.DoctorMobileNumber).HasColumnName("Doctor_MobileNumber");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(20)
                    .HasColumnName("Doctor_Name");

                entity.Property(e => e.DoctorOfficeNumber).HasColumnName("Doctor_OfficeNumber");

                entity.Property(e => e.DoctorProfileImage)
                    .HasMaxLength(50)
                    .HasColumnName("Doctor_ProfileImage");

                entity.Property(e => e.DoctorQualification)
                    .HasMaxLength(20)
                    .HasColumnName("Doctor_Qualification");

                entity.Property(e => e.DoctorSpeciality)
                    .HasMaxLength(30)
                    .HasColumnName("Doctor_Speciality");

                entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");

                entity.Property(e => e.StateId).HasColumnName("State_ID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblDoctors)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_DoctorCity");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.TblDoctors)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_HospitalID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblDoctors)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_DoctorState");
            });

            modelBuilder.Entity<TblHospital>(entity =>
            {
                entity.HasKey(e => e.HospitalId);

                entity.ToTable("tbl_Hospital");

                entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.HospitalAddressLine1)
                    .HasMaxLength(50)
                    .HasColumnName("Hospital_AddressLine1");

                entity.Property(e => e.HospitalAddressLine2)
                    .HasMaxLength(50)
                    .HasColumnName("Hospital_AddressLine2");

                entity.Property(e => e.HospitalAddressLine3)
                    .HasMaxLength(50)
                    .HasColumnName("Hospital_AddressLine3");

                entity.Property(e => e.HospitalEmail)
                    .HasMaxLength(20)
                    .HasColumnName("Hospital_Email");

                entity.Property(e => e.HospitalName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Hospital_Name");

                entity.Property(e => e.HospitalPhone).HasColumnName("Hospital_Phone");

                entity.Property(e => e.HospitalProfileImage)
                    .HasMaxLength(50)
                    .HasColumnName("Hospital_ProfileImage");

                entity.Property(e => e.HospitalSuburb)
                    .HasMaxLength(50)
                    .HasColumnName("Hospital_Suburb");

                entity.Property(e => e.StateId).HasColumnName("State_ID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblHospitals)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_HospitalCity");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblHospitals)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_HospitalState");
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("tbl_Patient");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.PatientAddressLine1)
                    .HasMaxLength(50)
                    .HasColumnName("Patient_AddressLine1");

                entity.Property(e => e.PatientAddressLine2)
                    .HasMaxLength(50)
                    .HasColumnName("Patient_AddressLine2");

                entity.Property(e => e.PatientAddressLine3)
                    .HasMaxLength(50)
                    .HasColumnName("Patient_AddressLine3");

                entity.Property(e => e.PatientEmail)
                    .HasMaxLength(20)
                    .HasColumnName("Patient_Email");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(20)
                    .HasColumnName("Patient_Name");

                entity.Property(e => e.PatientPhoneNumber).HasColumnName("Patient_PhoneNumber");

                entity.Property(e => e.StateId).HasColumnName("State_ID");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TblPatients)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("Fk_Appointment_Hospital");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblPatients)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_City");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblPatients)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_State");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("tbl_State");

                entity.Property(e => e.StateId).HasColumnName("State_ID");

                entity.Property(e => e.StateName)
                    .HasMaxLength(50)
                    .HasColumnName("State_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
