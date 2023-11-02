using APIv2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIv2.Data.Configurations
{
    public class HistorialRolConfiguration : IEntityTypeConfiguration<Historialrol>
    {
        public void Configure(EntityTypeBuilder<Historialrol> builder)
        {
            builder.HasKey(e => e.IdHistorialRol).HasName("PK__historia__7F8CBBB67982FCB0");

            builder.ToTable("historialrol");

            builder.Property(e => e.FechaCambio).HasColumnType("datetime");
            builder.Property(e => e.RolNuevo).HasDefaultValueSql("((0))");
            builder.Property(e => e.RolViejo).HasDefaultValueSql("((0))");

            builder.HasOne(d => d.LegajoEmpleadoNavigation).WithMany(p => p.Historialrols)
                .HasForeignKey(d => d.LegajoEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorialRol_Empleado");

            builder.HasOne(d => d.RolNuevoNavigation).WithMany(p => p.HistorialrolRolNuevoNavigations)
                .HasForeignKey(d => d.RolNuevo)
                .HasConstraintName("FK_HistorialRol_RolNuevo");

            builder.HasOne(d => d.RolViejoNavigation).WithMany(p => p.HistorialrolRolViejoNavigations)
                .HasForeignKey(d => d.RolViejo)
                .HasConstraintName("FK_HistorialRol_RolViejo");
        }
    }
}
