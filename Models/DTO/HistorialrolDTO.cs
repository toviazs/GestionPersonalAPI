namespace APIv2.Models.DTO
{
    public class HistorialrolDTO
    {
        public int IdHistorialRol { get; set; }
        public DateTime FechaCambio { get; set; }
        public int? RolViejo { get; set; }
        public int? RolNuevo { get; set; }
        public int LegajoEmpleado { get; set; }
    }
}
