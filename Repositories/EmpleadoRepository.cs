using APIv2.Data;
using APIv2.Models;
using APIv2.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

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
            EntityEntry<Empleado> x = _personalDb.Empleados.Add(emp);
            return x.Entity;
        }

        public void DeleteEmpleado(Empleado emp)
        {
            if (emp != null)
            {
                emp.EstadoEmpleado = "I";
                _personalDb.Empleados.Update(emp);
            }
        }

        public bool EditEmpleado(int legajoEmpleado, Empleado emp)
        {
            Empleado? empleadoExistente = _personalDb.Empleados.Find(legajoEmpleado);
            if (empleadoExistente == null)
            {
                return false;
            }
            else
            {
                _personalDb.Entry(empleadoExistente).State = EntityState.Detached;
            }

            _personalDb.Attach(emp);
            _personalDb.Entry(emp).State = EntityState.Modified;
            return true;
        }

        public List<Empleado> GetAll()
        {
            return _personalDb.Empleados.ToList();
        }

        public Empleado? GetById(int legajo)
        {
            return _personalDb.Empleados.FirstOrDefault(emp => emp.LegajoEmpleado == legajo);
        }
    }
}
