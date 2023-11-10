using APIv2.Models;
using APIv2.Models.DTO;
using Models.DTO;

namespace APIv2.Services.Contracts
{
    public interface IEmpleadoService
    {
        public List<EmpleadoDTO> GetAll();
        public List<EmpleadoDetalleDTO> GetAllEmpleadoDetalle();
        public EmpleadoDetalleDTO? GetEmpleadoDetalleById(int legajo);
        public EmpleadoDTO? GetById(int legajo);
        public EmpleadoDTO AddEmpleado(CreateEmpleadoDTO empDTO);
        bool EditEmpleado(int legajoEmpleado, EmpleadoDTO empDTO);
        public bool DeleteEmpleado(int legajo);
        public void SaveChanges();
    }
}
