using APIv2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISectorService
    {
        public List<SectorDTO> GetAll();
        public SectorDTO? GetById(int idSector);
    }
}
