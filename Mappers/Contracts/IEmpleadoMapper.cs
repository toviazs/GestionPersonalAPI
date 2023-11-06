using APIv2.Models;
using APIv2.Models.DTO;
using Models.DTO;

namespace APIv2.Mappers.Contracts
{
    public interface IEmpleadoMapper
    {
        public Empleado MapToEmpleado(EmpleadoDTO empleadoDTO);
        public Empleado MapToEmpleado(CreateEmpleadoDTO createEmpleadoDTO);
        public EmpleadoDTO MapToEmpleadoDTO(Empleado empleado);
        public EmpleadoDetalleDTO MapToEmpleadoDetalleDTO(Empleado empleado);
        public CreateEmpleadoDTO MapToCreateEmpleadoDTO(Empleado empleado);
    }
}
