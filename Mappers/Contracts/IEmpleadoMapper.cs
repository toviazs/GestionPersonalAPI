using APIv2.Models;
using APIv2.Models.DTO;

namespace APIv2.Mappers.Contracts
{
    public interface IEmpleadoMapper
    {
        public Empleado MapToEmpleado(EmpleadoDTO empleadoDTO);
        public EmpleadoDTO MapToEmpleadoDTO(Empleado empleado);
    }
}
