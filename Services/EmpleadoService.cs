using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Models.DTO;
using APIv2.Repositories.Contracts;
using APIv2.Services.Contracts;
using Mappers.Contracts;
using Repositories;
using Repositories.Contracts;
using System.ComponentModel;

namespace APIv2.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IEmpleadoMapper _empleadoMapper;
        private readonly ISectorRepository _sectorRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IRolMapper _rolMapper;
        public EmpleadoService(IEmpleadoRepository empleadoRepository, IEmpleadoMapper empleadoMapper, 
            ISectorRepository sectorRepository, IRolRepository rolRepository, IRolMapper rolMapper)
        {
            _empleadoRepository = empleadoRepository;
            _empleadoMapper = empleadoMapper;
            _sectorRepository = sectorRepository;
            _rolRepository = rolRepository;
            _rolMapper = rolMapper;
        }

        public Empleado AddEmpleado(EmpleadoDTO empDTO)
        {
            Empleado emp = _empleadoMapper.MapToEmpleado(empDTO);
            Empleado? empExistente = _empleadoRepository.GetById(emp.LegajoEmpleado);

            if (empExistente != null)
            {
                throw new Exception($"Ya existe un empleado con el legajo {emp.LegajoEmpleado}");
            }

            Rol? rol = _rolRepository.GetById(empDTO.RolIdRol ?? 0);
            if (rol == null)
            {
                throw new Exception($"No existe un rol con id {empDTO.RolIdRol}");
            }

            Sector? sector = _sectorRepository.GetById(empDTO.SectorIdSector ?? 0);
            if (sector == null)
            {
                throw new Exception($"No existe un sector con id {empDTO.SectorIdSector}");
            }

            return _empleadoRepository.AddEmpleado(emp);
        }

        public bool DeleteEmpleado(int legajo)
        {
            Empleado? empleado = _empleadoRepository.GetById(legajo);
            if (empleado == null || empleado.EstadoEmpleado == "I")
            {
                return false;
            }
            _empleadoRepository.DeleteEmpleado(empleado);
            return true;
        }

        public bool EditEmpleado(int legajoEmpleado, EmpleadoDTO empDTO)
        {
            Empleado empleadoEntidad = _empleadoMapper.MapToEmpleado(empDTO);

            Rol? rol = _rolRepository.GetById(empDTO.RolIdRol ?? 0);
            if (rol == null)
            {
                throw new Exception($"No existe un rol con id {empDTO.RolIdRol}");
            }

            Sector? sector = _sectorRepository.GetById(empDTO.SectorIdSector ?? 0);
            if (sector == null)
            {
                throw new Exception($"No existe un sector con id {empDTO.SectorIdSector}");
            }

            return _empleadoRepository.EditEmpleado(legajoEmpleado, empleadoEntidad);
        }

        public List<EmpleadoDTO> GetAll()  
        {
            List<EmpleadoDTO> empleados = new List<EmpleadoDTO>();
            empleados = _empleadoRepository.GetAll()
                .Select(emp => _empleadoMapper.MapToEmpleadoDTO(emp)).ToList();
            return empleados;
        }

        public List<EmpleadoDetalleDTO> GetAllEmpleadoDetalle()
        {
            List<EmpleadoDetalleDTO> empleados = new List<EmpleadoDetalleDTO>();
            empleados = _empleadoRepository.GetAll()
                .Select(emp => _empleadoMapper.MapToEmpleadoDetalleDTO(emp)).ToList();
            return empleados;
        }

        public EmpleadoDTO? GetById(int legajo)
        {
            Empleado? empleado = _empleadoRepository.GetById(legajo);
            if (empleado == null)
            {
                return null;
            }
            else
            {
                EmpleadoDTO empleadoDTO = _empleadoMapper.MapToEmpleadoDTO(empleado);
                return empleadoDTO;
            }
        }

        public void SaveChanges()
        {
            _empleadoRepository.SaveChanges();
        }
    }
}
