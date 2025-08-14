using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RVOE.entidades;

namespace RVOE.contextos;

public partial class PladseLocalContext : DbContext
{
    public PladseLocalContext()
    {
    }

    public PladseLocalContext(DbContextOptions<PladseLocalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302F15E43A4E5");

            entity.Property(e => e.RolId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B890F128B0");

            entity.Property(e => e.UsuarioId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__RolId__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
