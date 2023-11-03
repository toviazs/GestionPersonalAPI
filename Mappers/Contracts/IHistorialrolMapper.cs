using APIv2.Models.DTO;
using APIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers.Contracts
{
    public interface IHistorialsectorMapper
    {
        public Historialsector MapToHistorialsector(HistorialsectorDTO histSector);
        public HistorialsectorDTO MapToHistorialsectorDTO(Historialsector histSectorDTO);
    }
}
