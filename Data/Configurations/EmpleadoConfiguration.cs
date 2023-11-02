using APIv2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIv2.Data.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(e => e.LegajoEmpleado).HasName("PK__empleado__236928FBBDE7A3AD");

            builder.ToTable("empleado", tb =>
            {
                tb.HasTrigger("empleado_after_insert");
                tb.HasTrigger("empleado_after_update");
            });

            builder.Property(e => e.ApellidoEmpleado).HasMaxLength(200);
            builder.Property(e => e.Correo).HasMaxLength(200);
            builder.Property(e => e.Cuil).HasColumnName("CUIL");
            builder.Property(e => e.Direccion).HasMaxLength(200);
            builder.Property(e => e.EstadoEmpleado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            builder.Property(e => e.FechaContratacion).HasColumnType("date");
            builder.Property(e => e.FechaFinContrato).HasColumnType("date");
            builder.Property(e => e.FechaNacimiento).HasColumnType("date");
            builder.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            builder.Property(e => e.NombreEmpleado).HasMaxLength(200);
            builder.Property(e => e.RolIdRol).HasColumnName("Rol_IdRol");
            builder.Property(e => e.SectorIdSector).HasColumnName("Sector_IdSector");
            builder.Property(e => e.Telefono).HasMaxLength(20);

            builder.HasOne(d => d.LegajoSupervisorNavigation).WithMany(p => p.InverseLegajoSupervisorNavigation)
                .HasForeignKey(d => d.LegajoSupervisor)
                .HasConstraintName("FK_Empleado_LegajoSupervisor");

            builder.HasOne(d => d.RolIdRolNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.RolIdRol)
                .HasConstraintName("FK_Empleado_Rol");

            builder.HasOne(d => d.SectorIdSectorNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.SectorIdSector)
                .HasConstraintName("FK_Empleado_Sector");
        }
    }
}
