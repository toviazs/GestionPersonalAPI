using System;
using System.Collections.Generic;

namespace APIv2.Models;

public partial class Historialsector
{
    public int IdHistorialSector { get; set; }

    public DateTime FechaCambio { get; set; }

    public int? SectorViejo { get; set; }

    public int? SectorNuevo { get; set; }

    public int LegajoEmpleado { get; set; }

    public virtual Empleado LegajoEmpleadoNavigation { get; set; } = null!;

    public virtual Sector? SectorNuevoNavigation { get; set; }

    public virtual Sector? SectorViejoNavigation { get; set; }
}
