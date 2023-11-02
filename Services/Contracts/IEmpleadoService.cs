using APIv2.Models;
using APIv2.Models.DTO;

namespace APIv2.Services.Contracts
{
    public interface IEmpleadoService
    {
        public List<EmpleadoDTO> GetAll();
        public EmpleadoDTO? GetById(int legajo);
        public Empleado AddEmpleado(EmpleadoDTO empDTO);
        bool EditEmpleado(int legajoEmpleado, EmpleadoDTO empDTO);
        public void DeleteEmpleado(Empleado emp);
        public void SaveChanges();
    }
}
