using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProtoApp.Models;

public partial class TyCContext : DbContext
{
    public TyCContext()
    {
    }

    public TyCContext(DbContextOptions<TyCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certificado> Certificados { get; set; }

    public virtual DbSet<Titulo> Titulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LORE; Database=TyC;Trusted_Connection=True;TrustServerCertificate=yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Certificado");

            entity.Property(e => e.ApMaterno).HasMaxLength(50);
            entity.Property(e => e.ApPaterno).HasMaxLength(50);
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.NoControl).HasMaxLength(10);
            entity.Property(e => e.NombreCarrera).HasMaxLength(50);
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.Observaciones).HasMaxLength(50);
        });

        modelBuilder.Entity<Titulo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Titulo");

            entity.Property(e => e.ApMaterno).HasMaxLength(30);
            entity.Property(e => e.ApPaterno).HasMaxLength(30);
            entity.Property(e => e.ClavePlanDeEstudios).HasMaxLength(15);
            entity.Property(e => e.FechaActo).HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.NoControl).HasMaxLength(10);
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.Observaciones).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
