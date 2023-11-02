using APIv2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIv2.Data.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(e => e.IdRol).HasName("PK__rol__2A49584C36CAB4FE");

            builder.ToTable("rol");

            builder.Property(e => e.DescripcionRol).HasMaxLength(200);
            builder.Property(e => e.EstadoRol)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            builder.Property(e => e.NombreRol).HasMaxLength(45);
        }
    }
}