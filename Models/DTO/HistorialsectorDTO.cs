namespace APIv2.Models.DTO
{
    public class HistorialsectorDTO
    {
        public int IdHistorialSector { get; set; }
        public DateTime FechaCambio { get; set; }
        public int? SectorViejo { get; set; }
        public int? SectorNuevo { get; set; }
        public int LegajoEmpleado { get; set; }
    }
}
