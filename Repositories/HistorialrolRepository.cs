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
    public class HistorialrolRepository : BaseRepository, IHistorialrolRepository
    {
        private PersonalDB _personalDb;

        public HistorialrolRepository(PersonalDB personalDb) : base(personalDb)
        {
            _personalDb = personalDb;
        }

        public List<Historialrol> GetManyByLegajo(int legajoEmp)
        {
            return _personalDb.Historialrols.Where(histRol => histRol.LegajoEmpleado == legajoEmp).ToList();
        }
    }
}
