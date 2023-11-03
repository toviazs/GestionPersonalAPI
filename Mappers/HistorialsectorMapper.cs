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
    public class HistorialsectorMapper : IHistorialsectorMapper
    {
        public Historialsector MapToHistorialsector(HistorialsectorDTO histSectorDTO)
        {
            Historialsector histSector = new Historialsector
            {
                IdHistorialSector = histSectorDTO.IdHistorialSector,
                FechaCambio = histSectorDTO.FechaCambio,
                SectorViejo = histSectorDTO.SectorViejo,
                SectorNuevo = histSectorDTO.SectorNuevo,
                LegajoEmpleado = histSectorDTO.LegajoEmpleado
            };

            return histSector;
        }

        public HistorialsectorDTO MapToHistorialsectorDTO(Historialsector histSector)
        {
            HistorialsectorDTO histSectorDTO = new HistorialsectorDTO
            {
                IdHistorialSector = histSector.IdHistorialSector,
                FechaCambio = histSector.FechaCambio,
                SectorViejo = histSector.SectorViejo,
                SectorNuevo = histSector.SectorNuevo,
                LegajoEmpleado = histSector.LegajoEmpleado
            };

            return histSectorDTO;
        }
    }
}
