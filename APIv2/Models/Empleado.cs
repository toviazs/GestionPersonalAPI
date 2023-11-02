using System;
using System.Collections.Generic;

namespace APIv2.Models;

public partial class Empleado
{
    public int LegajoEmpleado { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string ApellidoEmpleado { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public DateTime FechaContratacion { get; set; }

    public long Cuil { get; set; }

    public DateTime? FechaFinContrato { get; set; }

    public int? LegajoSupervisor { get; set; }

    public string? EstadoEmpleado { get; set; }

    public int? RolIdRol { get; set; }

    public int? SectorIdSector { get; set; }

    public virtual ICollection<Historialrol> Historialrols { get; set; } = new List<Historialrol>();

    public virtual ICollection<Historialsector> Historialsectors { get; set; } = new List<Historialsector>();

    public virtual ICollection<Empleado> InverseLegajoSupervisorNavigation { get; set; } = new List<Empleado>();

    public virtual Empleado? LegajoSupervisorNavigation { get; set; }

    public virtual Rol? RolIdRolNavigation { get; set; }

    public virtual Sector? SectorIdSectorNavigation { get; set; }
}
