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
    public class HistorialsectorService : IHistorialsectorService
    {
        private readonly IHistorialsectorRepository _histSectorRepository;
        private readonly IHistorialsectorMapper _histSectorMapper;
        public HistorialsectorService(IHistorialsectorRepository histSectorRepository, IHistorialsectorMapper histSectorMapper)
        {
            _histSectorRepository = histSectorRepository;
            _histSectorMapper = histSectorMapper;
        }
        public List<HistorialsectorDTO> GetManyByLegajo(int legajoEmp)
        {
            List<HistorialsectorDTO> histSectores = new List<HistorialsectorDTO>();
            histSectores = _histSectorRepository.GetManyByLegajo(legajoEmp)
                .Select(histSector => _histSectorMapper.MapToHistorialsectorDTO(histSector)).ToList();
            return histSectores.OrderBy(histSector => histSector.FechaCambio).ToList();
        }
    }
}
