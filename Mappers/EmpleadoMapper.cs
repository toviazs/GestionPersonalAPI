using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Models.DTO;
using Models.DTO;

namespace APIv2.Mappers
{
    public class EmpleadoMapper : IEmpleadoMapper
    {
        public CreateEmpleadoDTO MapToCreateEmpleadoDTO(Empleado empleado)
        {
            CreateEmpleadoDTO empDTO = new CreateEmpleadoDTO
            {
                NombreEmpleado = empleado.NombreEmpleado,
                ApellidoEmpleado = empleado.ApellidoEmpleado,
                FechaNacimiento = empleado.FechaNacimiento,
                Genero = empleado.Genero,
                Direccion = empleado.Direccion,
                Telefono = empleado.Telefono,
                Correo = empleado.Correo,
                FechaContratacion = empleado.FechaContratacion,
                Cuil = empleado.Cuil,
                LegajoSupervisor = empleado.LegajoSupervisor,
                RolIdRol = empleado.RolIdRol,
                SectorIdSector = empleado.SectorIdSector,
            };

            return empDTO;
        }

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
                RolIdRol = empleadoDTO.RolIdRol,
                SectorIdSector = empleadoDTO.SectorIdSector,
            };

            return empleado;
        }

        public Empleado MapToEmpleado(CreateEmpleadoDTO createEmpleadoDTO)
        {
            Empleado empleado = new Empleado
            {
                NombreEmpleado = createEmpleadoDTO.NombreEmpleado,
                ApellidoEmpleado = createEmpleadoDTO.ApellidoEmpleado,
                FechaNacimiento = createEmpleadoDTO.FechaNacimiento,
                Genero = createEmpleadoDTO.Genero,
                Direccion = createEmpleadoDTO.Direccion,
                Telefono = createEmpleadoDTO.Telefono,
                Correo = createEmpleadoDTO.Correo,
                FechaContratacion = createEmpleadoDTO.FechaContratacion,
                Cuil = createEmpleadoDTO.Cuil,
                LegajoSupervisor = createEmpleadoDTO.LegajoSupervisor,
                RolIdRol = createEmpleadoDTO.RolIdRol,
                SectorIdSector = createEmpleadoDTO.SectorIdSector,
            };

            return empleado;
        }

        public EmpleadoDetalleDTO MapToEmpleadoDetalleDTO(Empleado empleado)
        {
            RolDTO? rolDTO = null;
            SectorDTO? sectorDTO = null;

            if (empleado.RolIdRolNavigation != null) 
            {
                rolDTO = new RolDTO
                {
                    IdRol = empleado.RolIdRolNavigation.IdRol,
                    NombreRol = empleado.RolIdRolNavigation.NombreRol,
                    DescripcionRol = empleado.RolIdRolNavigation.DescripcionRol
                };
            }    

            if (empleado.SectorIdSectorNavigation != null)
            {
                sectorDTO = new SectorDTO
                {
                    IdSector = empleado.SectorIdSectorNavigation.IdSector,
                    NombreSector = empleado.SectorIdSectorNavigation.NombreSector,
                    DescripcionSector = empleado.SectorIdSectorNavigation.DescripcionSector
                };
            }

            EmpleadoDetalleDTO empDetDTO = new EmpleadoDetalleDTO
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
                Rol = rolDTO,
                Sector = sectorDTO
            };

            return empDetDTO;
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
                RolIdRol = empleado.RolIdRol,
                SectorIdSector = empleado.SectorIdSector,
            };

            return empleadoDTO;
        }
    }
}
