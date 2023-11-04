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
    public class RolMapper : IRolMapper
    {
        public Rol MapToRol(RolDTO rolDTO)
        {
            Rol rol = new Rol
            {
                IdRol = rolDTO.IdRol,
                NombreRol = rolDTO.NombreRol,
                DescripcionRol = rolDTO.DescripcionRol,
            };

            return rol;
        }

        public RolDTO MapToRolDTO(Rol rol)
        {
            RolDTO rolDTO = new RolDTO
            {
                IdRol = rol.IdRol,
                NombreRol = rol.NombreRol,
                DescripcionRol = rol.DescripcionRol,
            };

            return rolDTO;
        }
    }
}
