using System;
using System.Collections.Generic;
using AngularWithAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularWithAPI.Data;

public partial class DoctorBookingContext : DbContext
{
    public DoctorBookingContext()
    {
    }

    public DoctorBookingContext(DbContextOptions<DoctorBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<DoctorDetail> DoctorDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog = DoctorBooking; integrated security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Appid).HasName("PK__Appointm__C00F024D805E4C48");

            entity.ToTable("Appointment");

            entity.Property(e => e.Appid).HasColumnName("appid");
            entity.Property(e => e.AppoitmentTime).HasColumnName("appoitment_time");
            entity.Property(e => e.DoctorName).HasColumnName("Doctor_name");
            entity.Property(e => e.PatientAddress).HasColumnName("patient_address");
            entity.Property(e => e.PatientAge).HasColumnName("patient_age");
            entity.Property(e => e.PatientGender)
                .HasMaxLength(15)
                .HasColumnName("patient_gender");
            entity.Property(e => e.PatientName).HasColumnName("Patient_name");
            entity.Property(e => e.PatientNumber).HasColumnName("patient_number");
            entity.Property(e => e.SpecializationPatientNeed).HasColumnName("specialization_patient_need");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.VisitingDate)
                .HasColumnType("date")
                .HasColumnName("visiting_Date");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Doctorid)
                .HasConstraintName("FK__Appointme__Docto__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK__Appointme__useri__4E88ABD4");
        });

        modelBuilder.Entity<DoctorDetail>(entity =>
        {
            entity.HasKey(e => e.Doctorid).HasName("PK__DoctorDe__2DC512B7E5E9B90F");

            entity.Property(e => e.ContactNumber).HasColumnName("contact_number");
            entity.Property(e => e.DoctorName).HasColumnName("Doctor_name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .HasColumnName("gender");
            entity.Property(e => e.Specialization).HasColumnName("specialization");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.DoctorDetails)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK__DoctorDet__useri__4BAC3F29");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__Users__CBA1B257C9A84B28");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Hashkey).HasColumnName("hashkey");
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
