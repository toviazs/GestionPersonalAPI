using APIv2.Models.DTO;
using APIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers.Contracts
{
    public interface IHistorialrolMapper
    {
        public Historialrol MapToHistorialrol(HistorialrolDTO histRol);
        public HistorialrolDTO MapToHistorialrolDTO(Historialrol histRolDTO);
    }
}
