using APIv2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIv2.Data.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.HasKey(e => e.IdSector).HasName("PK__sector__D0011C184DD5EA74");

            builder.ToTable("sector");

            builder.Property(e => e.DescripcionSector).HasMaxLength(200);
            builder.Property(e => e.EstadoSector)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            builder.Property(e => e.NombreSector).HasMaxLength(45);
        }
    }
}