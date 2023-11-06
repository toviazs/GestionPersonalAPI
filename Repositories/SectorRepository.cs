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
    public class SectorRepository : BaseRepository, ISectorRepository
    {
        private PersonalDB _personalDb;
        public SectorRepository(PersonalDB personalDb) : base(personalDb)
        {
            _personalDb = personalDb;
        }
        public List<Sector> GetAll()
        {
            return _personalDb.Sectors
                .Where(sector => sector.EstadoSector == "A")
                .ToList();
        }

        public Sector? GetById(int idSector)
        {
            return _personalDb.Sectors
                .Where(sector => sector.EstadoSector == "A")
                .ToList()
                .FirstOrDefault(sector => sector.IdSector == idSector);
        }
    }
}
