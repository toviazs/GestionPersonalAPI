using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Models.DTO;

namespace APIv2.Mappers
{
    public class EmpleadoMapper : IEmpleadoMapper
    {
        public Empleado MapToEmpleado(EmpleadoDTO empleadoDTO)
        {
            Empleado empleado = new Empleado
            {
                LegajoEmpleado = empleadoDTO.LegajoEmpleado,
                NombreEmpleado = empleadoDTO.NombreEmpleado,
                ApellidoEmpleado = empleadoDTO.ApellidoEmpleado,
                FechaNacimiento = empleadoDTO.FechaNacimiento,
                Genero = empleadoDTO.Genero,
                Direccion = empleadoDTO.Direccion,
                Telefono = empleadoDTO.Telefono,
                Correo = empleadoDTO.Correo,
                FechaContratacion = empleadoDTO.FechaContratacion,
                Cuil = empleadoDTO.Cuil,
                FechaFinContrato = empleadoDTO.FechaFinContrato,
                LegajoSupervisor = empleadoDTO.LegajoSupervisor,
                EstadoEmpleado = empleadoDTO.EstadoEmpleado,
                RolIdRol = empleadoDTO.RolIdRol,
                SectorIdSector = empleadoDTO.SectorIdSector,
            };

            return empleado;
        }

        public EmpleadoDTO MapToEmpleadoDTO(Empleado empleado)
        {
            EmpleadoDTO empleadoDTO = new EmpleadoDTO
            {
                LegajoEmpleado = empleado.LegajoEmpleado,
                NombreEmpleado = empleado.NombreEmpleado,
                ApellidoEmpleado = empleado.ApellidoEmpleado,
                FechaNacimiento = empleado.FechaNacimiento,
                Genero = empleado.Genero,
                Direccion = empleado.Direccion,
                Telefono = empleado.Telefono,
                Correo = empleado.Correo,
                FechaContratacion = empleado.FechaContratacion,
                Cuil = empleado.Cuil,
                FechaFinContrato = empleado.FechaFinContrato,
                LegajoSupervisor = empleado.LegajoSupervisor,
                EstadoEmpleado = empleado.EstadoEmpleado,
                RolIdRol = empleado.RolIdRol,
                SectorIdSector = empleado.SectorIdSector,
            };

            return empleadoDTO;
        }
    }
}
