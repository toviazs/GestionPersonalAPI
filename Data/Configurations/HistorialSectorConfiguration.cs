using APIv2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIv2.Data.Configurations
{
    public class HistorialSectorConfiguration : IEntityTypeConfiguration<Historialsector>
    {
        public void Configure(EntityTypeBuilder<Historialsector> builder)
        {
            builder.HasKey(e => e.IdHistorialSector).HasName("PK__historia__D10D0CC0A97BF0A0");

            builder.ToTable("historialsector");

            builder.Property(e => e.FechaCambio).HasColumnType("datetime");
            builder.Property(e => e.SectorNuevo).HasDefaultValueSql("((0))");
            builder.Property(e => e.SectorViejo).HasDefaultValueSql("((0))");

            builder.HasOne(d => d.LegajoEmpleadoNavigation).WithMany(p => p.Historialsectors)
                .HasForeignKey(d => d.LegajoEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorialSector_Empleado");

            builder.HasOne(d => d.SectorNuevoNavigation).WithMany(p => p.HistorialsectorSectorNuevoNavigations)
                .HasForeignKey(d => d.SectorNuevo)
                .HasConstraintName("FK_HistorialSector_SectorNuevo");

            builder.HasOne(d => d.SectorViejoNavigation).WithMany(p => p.HistorialsectorSectorViejoNavigations)
                .HasForeignKey(d => d.SectorViejo)
                .HasConstraintName("FK_HistorialSector_SectorViejo");
        }
    }
}