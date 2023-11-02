using APIv2.Data.Configurations;
using APIv2.Models;
using Microsoft.EntityFrameworkCore;

namespace APIv2.Data;

public partial class PersonalDB : DbContext
{
    public PersonalDB(DbContextOptions<PersonalDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }
    public virtual DbSet<Historialrol> Historialrols { get; set; }
    public virtual DbSet<Historialsector> Historialsectors { get; set; }
    public virtual DbSet<Rol> Rols { get; set; }
    public virtual DbSet<Sector> Sectors { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplicar configuraciones para cada entidad
        modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());
        modelBuilder.ApplyConfiguration(new HistorialRolConfiguration());
        modelBuilder.ApplyConfiguration(new HistorialSectorConfiguration());
        modelBuilder.ApplyConfiguration(new RolConfiguration());
        modelBuilder.ApplyConfiguration(new SectorConfiguration());

        //OnModelCreatingPartial(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
