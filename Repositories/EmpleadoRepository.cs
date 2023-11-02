using APIv2.Data;
using APIv2.Models;
using APIv2.Repositories.Contracts;

namespace APIv2.Repositories
{
    public class EmpleadoRepository : BaseRepository, IEmpleadoRepository
    {
        private PersonalDB _personalDb;
        public EmpleadoRepository(PersonalDB personalDb) : base(personalDb)
        {
            _personalDb = personalDb;
        }

        public Empleado AddEmpleado(Empleado emp)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmpleado(Empleado emp)
        {
            throw new NotImplementedException();
        }

        public bool EditEmpleado(int legajoEmpleado, Empleado emp)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> GetAll()
        {
            return _personalDb.Empleados.ToList();
        }

        public Empleado? GetById(int legajo)
        {
            throw new NotImplementedException();
        }
    }
}
