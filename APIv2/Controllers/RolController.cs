using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Data;
using APIv2.Models.DTO;
using APIv2.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using APIv2.Data.Configurations;
using System.ComponentModel.DataAnnotations;
using Validators.Contracts;
using Mappers.Contracts;
using Microsoft.AspNetCore.Identity;
using APIv2.Services;
using Microsoft.AspNetCore.Authorization;

namespace APIv2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Rol")]
    public class RolController : Controller
    {
        private readonly IRolService _rolService;
        private readonly IRolMapper _rolMapper;

        public RolController(IRolService rolService, IRolMapper rolMapper)
        {
            _rolService = rolService;
            _rolMapper = rolMapper;
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            ResultDTO<List<RolDTO>> result = new ResultDTO<List<RolDTO>>();
            result.Results = _rolService.GetAll();
            result.StatusCode = Ok().StatusCode;
            return Ok(result);
        }

        [HttpGet]
        [Route("{idRol:int}")]
        public ActionResult GetRolById([FromRoute] int idRol)
        {
            ResultDTO<RolDTO> result = new ResultDTO<RolDTO>();
            RolDTO? rol = _rolService.GetById(idRol);
            if (rol == null)
            {
                result.ErrorsMessages.Add("Rol no encontrado!");
                result.StatusCode = NotFound().StatusCode;
                return NotFound(result);
            }
            else
            {
                result.Results = rol;
                result.StatusCode = Ok().StatusCode;
                return Ok(result);
            }
        }

    }
}
