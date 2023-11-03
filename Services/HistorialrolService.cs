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
    public class HistorialrolService : IHistorialrolService
    {
        private readonly IHistorialrolRepository _histRolRepository;
        private readonly IHistorialrolMapper _histRolMapper;
        public HistorialrolService(IHistorialrolRepository histRolRepository, IHistorialrolMapper histRolMapper)
        {
            _histRolRepository = histRolRepository;
            _histRolMapper = histRolMapper;
        }
        public List<HistorialrolDTO> GetManyByLegajo(int legajoEmp)
        {
            List<HistorialrolDTO> histRoles = new List<HistorialrolDTO>();
            histRoles = _histRolRepository.GetManyByLegajo(legajoEmp)
                .Select(histRol => _histRolMapper.MapToHistorialrolDTO(histRol)).ToList();
            return histRoles.OrderBy(histRol => histRol.FechaCambio).ToList();
        }
    }
}
