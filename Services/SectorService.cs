using APIv2.Models;
using APIv2.Models.DTO;
using Mappers;
using Mappers.Contracts;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly ISectorMapper _sectorMapper;
        public SectorService(ISectorRepository sectorRepository, ISectorMapper sectorMapper)
        {
            _sectorRepository = sectorRepository;
            _sectorMapper = sectorMapper;
        }
        public List<SectorDTO> GetAll()
        {
            List<SectorDTO> sectores = new List<SectorDTO>();
            sectores = _sectorRepository.GetAll()
                .Select(sector => _sectorMapper.MapToSectorDTO(sector)).ToList();
            return sectores;
        }

        public SectorDTO? GetById(int idSector)
        {
            Sector? sector = _sectorRepository.GetById(idSector);
            if (sector == null)
            {
                return null;
            }
            else
            {
                SectorDTO sectorDTO = _sectorMapper.MapToSectorDTO(sector);
                return sectorDTO;
            }
        }
    }
}
