using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Models.DTO;
using APIv2.Repositories.Contracts;
using APIv2.Services.Contracts;
using System.ComponentModel;

namespace APIv2.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IEmpleadoMapper _empleadoMapper;
        public EmpleadoService(IEmpleadoRepository empleadoRepository, IEmpleadoMapper empleadoMapper)
        {
            _empleadoRepository = empleadoRepository;
            _empleadoMapper = empleadoMapper;
        }

        public Empleado AddEmpleado(EmpleadoDTO empDTO)
        {
            Empleado emp = _empleadoMapper.MapToEmpleado(empDTO);
            Empleado? empExistente = _empleadoRepository.GetById(emp.LegajoEmpleado);
            if (empExistente == null)
            {
                return _empleadoRepository.AddEmpleado(emp);
            }
            throw new Exception($"Ya existe un empleado con el legajo {emp.LegajoEmpleado}");
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
            return _empleadoRepository.EditEmpleado(legajoEmpleado, empleadoEntidad);
        }

        public List<EmpleadoDTO> GetAll()  
        {
            List<EmpleadoDTO> empleados = new List<EmpleadoDTO>();
            empleados = _empleadoRepository.GetAll()
                .Select(emp => _empleadoMapper.MapToEmpleadoDTO(emp)).ToList();
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
