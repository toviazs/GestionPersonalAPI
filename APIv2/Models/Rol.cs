using System;
using System.Collections.Generic;

namespace APIv2.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public string? DescripcionRol { get; set; }

    public string? EstadoRol { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Historialrol> HistorialrolRolNuevoNavigations { get; set; } = new List<Historialrol>();

    public virtual ICollection<Historialrol> HistorialrolRolViejoNavigations { get; set; } = new List<Historialrol>();
}
