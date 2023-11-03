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
    public class HistorialsectorRepository : BaseRepository, IHistorialsectorRepository
    {
        private PersonalDB _personalDb;

        public HistorialsectorRepository(PersonalDB personalDb) : base(personalDb)
        {
            _personalDb = personalDb;
        }

        public List<Historialsector> GetManyByLegajo(int legajoEmp)
        {
            return _personalDb.Historialsectors.Where(histSector => histSector.LegajoEmpleado == legajoEmp).ToList();
        }
    }
}
