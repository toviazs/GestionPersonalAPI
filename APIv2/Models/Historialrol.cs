using System;
using System.Collections.Generic;

namespace APIv2.Models;

public partial class Historialrol
{
    public int IdHistorialRol { get; set; }

    public DateTime FechaCambio { get; set; }

    public int? RolViejo { get; set; }

    public int? RolNuevo { get; set; }

    public int LegajoEmpleado { get; set; }

    public virtual Empleado LegajoEmpleadoNavigation { get; set; } = null!;

    public virtual Rol? RolNuevoNavigation { get; set; }

    public virtual Rol? RolViejoNavigation { get; set; }
}
