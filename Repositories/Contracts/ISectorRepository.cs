using APIv2.Data;
using APIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ISectorRepository : IBaseRepository
    {
        public List<Sector> GetAll();
        public Sector? GetById(int idSector);
    }
}
