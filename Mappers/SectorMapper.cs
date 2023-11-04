using APIv2.Models;
using APIv2.Models.DTO;
using Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class SectorMapper : ISectorMapper
    {
        public Sector MapToSector(SectorDTO sectorDTO)
        {
            Sector sector = new Sector
            {
                IdSector = sectorDTO.IdSector,
                NombreSector = sectorDTO.NombreSector,
                DescripcionSector = sectorDTO.DescripcionSector,
            };

            return sector;
        }

        public SectorDTO MapToSectorDTO(Sector sector)
        {
            SectorDTO sectorDTO = new SectorDTO
            {
                IdSector = sector.IdSector,
                NombreSector = sector.NombreSector,
                DescripcionSector = sector.DescripcionSector,
            };

            return sectorDTO;
        }
    }
}
