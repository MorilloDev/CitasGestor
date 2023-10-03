using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CitasGestor.Models;

public partial class AppointmentsContext : DbContext
{
    public AppointmentsContext()
    {
    }

    public AppointmentsContext(DbContextOptions<AppointmentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        if (!optionsBuilder.IsConfigured)
     {
         
     }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("appointments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountPayable)
                .HasPrecision(10, 2)
                .HasColumnName("Amount_payable");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("appointment_date");
            entity.Property(e => e.Attendant)
                .HasMaxLength(255)
                .HasColumnName("attendant");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("creation_date");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'agendando'")
                .HasColumnType("enum('agendando','completado','perdida')")
                .HasColumnName("status");
            entity.Property(e => e.UserAge).HasColumnName("user_age");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
