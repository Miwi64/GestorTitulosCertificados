using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProtoApp.Models;

public partial class TitulosCertificadosContext : DbContext
{
    public TitulosCertificadosContext()
    {
    }

    public TitulosCertificadosContext(DbContextOptions<TitulosCertificadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Certificado> Certificados { get; set; }

    public virtual DbSet<Titulo> Titulos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LORE; User ID=sa; Database=TitulosCertificados;Trusted_Connection=True;TrustServerCertificate=yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.Property(e => e.CarreraId)
                .ValueGeneratedNever()
                .HasColumnName("CarreraID");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Tipo).HasMaxLength(20);
        });

        modelBuilder.Entity<Certificado>(entity =>
        {
            entity.HasKey(e => e.IdCertificado);

            entity.ToTable("Certificado");

            entity.Property(e => e.ApellidoMaterno).HasMaxLength(30);
            entity.Property(e => e.ApellidoPaterno).HasMaxLength(30);
            entity.Property(e => e.Carrera).HasMaxLength(50);
            entity.Property(e => e.FechaRegCert).HasColumnType("date");
            entity.Property(e => e.Nombre).HasMaxLength(30);
            entity.Property(e => e.NumeroControl).HasMaxLength(10);
            entity.Property(e => e.Observaciones).HasMaxLength(50);
        });

        modelBuilder.Entity<Titulo>(entity =>
        {
            entity.HasKey(e => e.IdTitulo);

            entity.ToTable("Titulo");

            entity.Property(e => e.ClavePlanEstudios).HasMaxLength(15);
            entity.Property(e => e.FechaActo).HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.NumeroControl).HasMaxLength(10);
            entity.Property(e => e.Observaciones).HasMaxLength(50);
            entity.Property(e => e.TituloLicenciatura).HasMaxLength(8);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Usuario");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Contra).HasMaxLength(50);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
