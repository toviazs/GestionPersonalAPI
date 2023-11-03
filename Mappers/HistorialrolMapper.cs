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
    public class HistorialrolMapper : IHistorialrolMapper
    {
        public Historialrol MapToHistorialrol(HistorialrolDTO histRolDTO)
        {
            Historialrol histRol = new Historialrol
            {
                IdHistorialRol = histRolDTO.IdHistorialRol,
                FechaCambio = histRolDTO.FechaCambio,
                RolViejo = histRolDTO.RolViejo,
                RolNuevo = histRolDTO.RolNuevo,
                LegajoEmpleado = histRolDTO.LegajoEmpleado
            };

            return histRol;
        }

        public HistorialrolDTO MapToHistorialrolDTO(Historialrol histRol)
        {
            HistorialrolDTO histRolDTO = new HistorialrolDTO
            {
                IdHistorialRol = histRol.IdHistorialRol,
                FechaCambio = histRol.FechaCambio,
                RolViejo = histRol.RolViejo,
                RolNuevo = histRol.RolNuevo,
                LegajoEmpleado = histRol.LegajoEmpleado
            };

            return histRolDTO;
        }
    }
}
