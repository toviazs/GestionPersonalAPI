namespace APIv2.Models.DTO
{
    public class EmpleadoDTO
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
    }
}