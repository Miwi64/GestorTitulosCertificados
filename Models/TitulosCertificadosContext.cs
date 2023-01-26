﻿using System;
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

    public virtual DbSet<Certificado> Certificados { get; set; }

    public virtual DbSet<Titulo> Titulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MIHAYA\\SERVIDOR; User ID=sa; Password=SP105rf; Database=TitulosCertificados;Trusted_Connection=False;TrustServerCertificate=yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

            entity.Property(e => e.FechaActo).HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.NumeroControl).HasMaxLength(10);
            entity.Property(e => e.Observaciones).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}