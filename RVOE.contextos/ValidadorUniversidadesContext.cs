using Microsoft.EntityFrameworkCore;
using RVOE.entidades.ValidadorEntidades;

namespace RVOE.contextos;

public partial class ValidadorUniversidadesContext : DbContext
{
    public ValidadorUniversidadesContext()
    {
    }

    public ValidadorUniversidadesContext(DbContextOptions<ValidadorUniversidadesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EnvioRecepcion> EnvioRecepcion { get; set; }

    public virtual DbSet<Escuelas> Escuelas { get; set; }

    public virtual DbSet<EstatusEscuela> EstatusEscuela { get; set; }

    public virtual DbSet<HistoricosRVOE> HistoricosRVOE { get; set; }

    public virtual DbSet<PlanesProgramas> PlanesProgramas { get; set; }

    public virtual DbSet<Requisitos> Requisitos { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<TiposEscuela> TiposEscuela { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnvioRecepcion>(entity =>
        {
            entity.Property(e => e.EnvioRecepcionId).IsFixedLength();
            entity.Property(e => e.TipoMovimiento).IsFixedLength();

            entity.HasOne(d => d.Escuela).WithMany(p => p.EnvioRecepcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnvioRecepcion_Escuelas");
        });

        modelBuilder.Entity<Escuelas>(entity =>
        {
            entity.Property(e => e.EscuelaId).ValueGeneratedNever();

            entity.HasOne(d => d.Estatus).WithMany(p => p.Escuelas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Escuelas_EstatusEscuela");

            entity.HasOne(d => d.TipoEscuela).WithMany(p => p.Escuelas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Escuelas_TiposEscuela");
        });

        modelBuilder.Entity<EstatusEscuela>(entity =>
        {
            entity.Property(e => e.EstatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<HistoricosRVOE>(entity =>
        {
            entity.Property(e => e.HistoricoRVOEId).ValueGeneratedNever();
            entity.Property(e => e.RVOE).IsFixedLength();

            entity.HasOne(d => d.Plan).WithMany(p => p.HistoricosRVOE)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoricosRVOE_PlanesProgramas");
        });

        modelBuilder.Entity<PlanesProgramas>(entity =>
        {
            entity.Property(e => e.PlanId).ValueGeneratedNever();

            entity.HasOne(d => d.Escuela).WithMany(p => p.PlanesProgramas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanesProgramas_Escuelas");
        });

        modelBuilder.Entity<Requisitos>(entity =>
        {
            entity.Property(e => e.RequisitosId).ValueGeneratedNever();

            entity.HasOne(d => d.Escuela).WithMany(p => p.Requisitos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requisitos_Escuelas");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.Property(e => e.RolId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TiposEscuela>(entity =>
        {
            entity.Property(e => e.TipoEscuelaId).ValueGeneratedNever();
            entity.Property(e => e.NombreTipo).HasComment("Si es pública, privada, etc");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.Property(e => e.UsuarioId).ValueGeneratedNever();

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
