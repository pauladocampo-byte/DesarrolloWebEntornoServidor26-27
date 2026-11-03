using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FutbolistaDBFirst.Models;

public partial class FutbolistasDbContext : DbContext
{
    public FutbolistasDbContext()
    {
    }

    public FutbolistasDbContext(DbContextOptions<FutbolistasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Futbolista> Futbolistas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FutbolistasDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Futbolista>(entity =>
        {
            entity.HasIndex(e => e.EquipoId, "IX_Futbolistas_EquipoId");

            entity.Property(e => e.PrecioMercado).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Equipo).WithMany(p => p.Futbolista).HasForeignKey(d => d.EquipoId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
