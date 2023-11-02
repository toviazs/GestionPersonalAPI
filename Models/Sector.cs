using System;
using System.Collections.Generic;

namespace APIv2.Models;

public partial class Sector
{
    public int IdSector { get; set; }

    public string? NombreSector { get; set; }

    public string? DescripcionSector { get; set; }

    public string? EstadoSector { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Historialsector> HistorialsectorSectorNuevoNavigations { get; set; } = new List<Historialsector>();

    public virtual ICollection<Historialsector> HistorialsectorSectorViejoNavigations { get; set; } = new List<Historialsector>();
}
