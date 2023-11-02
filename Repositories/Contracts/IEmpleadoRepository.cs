using APIv2.Data;
using APIv2.Models;

namespace APIv2.Repositories.Contracts
{
    public interface IEmpleadoRepository : IBaseRepository
    {
        public List<Empleado> GetAll();
        public Empleado? GetById(int legajo);
        public Empleado AddEmpleado(Empleado emp);
        bool EditEmpleado(int legajoEmpleado, Empleado emp);
        public void DeleteEmpleado(Empleado emp);
    }
}
