using APIv2.Data;
using APIv2.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RolRepository : BaseRepository, IRolRepository
    {
        private PersonalDB _personalDb;
        public RolRepository(PersonalDB personalDb) : base(personalDb)
        {
            _personalDb = personalDb;
        }

        public List<Rol> GetAll()
        {
            return _personalDb.Rols
                .Where(rol => rol.EstadoRol == "A")
                .ToList();
        }

        public Rol? GetById(int idRol)
        {
            return _personalDb.Rols
                .Where(rol => rol.EstadoRol == "A")
                .ToList()
                .FirstOrDefault(rol => rol.IdRol == idRol);
        }
    }
}
