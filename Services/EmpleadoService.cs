using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Models.DTO;
using APIv2.Repositories.Contracts;
using APIv2.Services.Contracts;

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
            throw new NotImplementedException();
        }

        public void DeleteEmpleado(Empleado emp)
        {
            throw new NotImplementedException();
        }

        public bool EditEmpleado(int legajoEmpleado, EmpleadoDTO empDTO)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
