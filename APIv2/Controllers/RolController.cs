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

namespace APIv2.Controllers
{
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
            throw new NotImplementedException();
        }

    }
}
