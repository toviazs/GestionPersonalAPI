using APIv2.Mappers;
using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Models.DTO;
using APIv2.Repositories;
using APIv2.Repositories.Contracts;
using APIv2.Services.Contracts;
using Mappers.Contracts;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        private readonly IRolMapper _rolMapper;
        public RolService(IRolRepository rolRepository, IRolMapper rolMapper)
        {
            _rolRepository = rolRepository;
            _rolMapper = rolMapper;
        }
        public List<RolDTO> GetAll()
        {
            List<RolDTO> roles = new List<RolDTO>();
            roles = _rolRepository.GetAll()
                .Select(rol => _rolMapper.MapToRolDTO(rol)).ToList();
            return roles;
        }

        public RolDTO? GetById(int idRol)
        {
            Rol? rol = _rolRepository.GetById(idRol);
            if (rol == null)
            {
                return null;
            }
            else
            {
                RolDTO rolDTO = _rolMapper.MapToRolDTO(rol);
                return rolDTO;
            }
        }
    }
}
