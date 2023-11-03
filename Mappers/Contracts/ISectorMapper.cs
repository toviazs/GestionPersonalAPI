using APIv2.Models.DTO;
using APIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers.Contracts
{
    public interface ISectorMapper
    {
        public Sector MapToSector(SectorDTO sectorDTO);
        public SectorDTO MapToSectorDTO(Sector sector);
    }
}
