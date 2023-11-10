using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Models.DTO;
using APIv2.Repositories.Contracts;
using APIv2.Services.Contracts;
using Mappers.Contracts;
using Models.DTO;
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

        public EmpleadoDTO AddEmpleado(CreateEmpleadoDTO empDTO)
        {
            Empleado emp = _empleadoMapper.MapToEmpleado(empDTO);
            Empleado? empExistente = _empleadoRepository.GetById(emp.LegajoEmpleado);

            // Unique
            if (empExistente != null)
            {
                throw new Exception($"Ya existe un empleado con el legajo {emp.LegajoEmpleado}.");
            }

            // Valid supervisor
            int legajoSupervisor = empDTO.LegajoSupervisor ?? 0;
            _ = _empleadoRepository.GetById(legajoSupervisor) ?? throw new Exception($"No existe ningún empleado supervisor con el legajo {legajoSupervisor}.");

            // Valid rol
            _ = _rolRepository.GetById(empDTO.RolIdRol ?? 0) ?? throw new Exception($"No existe un rol con id {empDTO.RolIdRol}");

            // Valid sector
            _ = _sectorRepository.GetById(empDTO.SectorIdSector ?? 0) ?? throw new Exception($"No existe un sector con id {empDTO.SectorIdSector}");

            return _empleadoMapper.MapToEmpleadoDTO(_empleadoRepository.AddEmpleado(emp));
        }

        public bool DeleteEmpleado(int legajo)
        {
            Empleado? empleado = _empleadoRepository.GetById(legajo);

            // Valid/active employee
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

            // Valid rol
            _ = _rolRepository.GetById(empDTO.RolIdRol ?? 0) ?? throw new Exception($"No existe un rol con id {empDTO.RolIdRol}");

            // Valid sector
            _ = _sectorRepository.GetById(empDTO.SectorIdSector ?? 0) ?? throw new Exception($"No existe un sector con id {empDTO.SectorIdSector}");

            // Valid supervisor
            int legajoSupervisor = empDTO.LegajoSupervisor ?? 0;
            _ = _empleadoRepository.GetById(legajoSupervisor) ?? throw new Exception($"No existe ningún empleado supervisor con el legajo {legajoSupervisor}.");

            // Employee != supervisor
            if (legajoSupervisor == legajoEmpleado)
            {
                throw new Exception($"El empleado con legajo {legajoEmpleado} no puede supervisarse a sí mismo.");
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

        public EmpleadoDetalleDTO? GetEmpleadoDetalleById(int legajo)
        {
            Empleado? empleado = _empleadoRepository.GetById(legajo);

            // Existing employee
            if (empleado == null)
            {
                return null;
            }
            
            EmpleadoDetalleDTO empDetDTO = _empleadoMapper.MapToEmpleadoDetalleDTO(empleado);
            return empDetDTO;
        }

        public EmpleadoDTO? GetById(int legajo)
        {
            Empleado? empleado = _empleadoRepository.GetById(legajo);

            // Existing employee
            if (empleado == null)
            {
                return null;
            }

            EmpleadoDTO empleadoDTO = _empleadoMapper.MapToEmpleadoDTO(empleado);
            return empleadoDTO;
        }

        public void SaveChanges()
        {
            _empleadoRepository.SaveChanges();
        }
    }
}
