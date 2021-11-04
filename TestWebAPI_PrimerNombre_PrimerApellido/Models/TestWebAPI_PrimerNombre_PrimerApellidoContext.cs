using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestWebAPI_PrimerNombre_PrimerApellido.Models
{
    public partial class TestWebAPI_PrimerNombre_PrimerApellidoContext : DbContext
    {
        public TestWebAPI_PrimerNombre_PrimerApellidoContext()
        {
        }

        public TestWebAPI_PrimerNombre_PrimerApellidoContext(DbContextOptions<TestWebAPI_PrimerNombre_PrimerApellidoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dosi> Doses { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Vacuna> Vacunas { get; set; }
        public virtual DbSet<VacunacionCovid19> VacunacionCovid19s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLSERVER;Initial Catalog=TestWebAPI_PrimerNombre_PrimerApellido;Persist Security Info=True;User ID=sa;Password=Poi16poi16");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dosi>(entity =>
            {
                entity.HasKey(e => e.DosisVacunaId);

                entity.ToTable("Dosis");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Expediente).HasMaxLength(20);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha Nacimiento");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TipoEdad).HasMaxLength(10);
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<VacunacionCovid19>(entity =>
            {
                entity.HasKey(e => e.VacunacionId);

                entity.ToTable("Vacunacion_Covid19");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FkDosisId).HasColumnName("FK_DosisId");

                entity.Property(e => e.FkPacienteId).HasColumnName("FK_PacienteId");

                entity.Property(e => e.FkVacunaId).HasColumnName("FK_VacunaId");

                entity.HasOne(d => d.FkDosis)
                    .WithMany(p => p.VacunacionCovid19s)
                    .HasForeignKey(d => d.FkDosisId)
                    .HasConstraintName("FK_Vacunacion_Covid19_Dosis");

                entity.HasOne(d => d.FkVacuna)
                    .WithMany(p => p.VacunacionCovid19s)
                    .HasForeignKey(d => d.FkVacunaId)
                    .HasConstraintName("FK_Vacunacion_Covid19_Vacunas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
