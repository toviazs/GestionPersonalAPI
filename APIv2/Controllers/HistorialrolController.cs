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
using Services.Contracts;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace APIv2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("HistorialRol")]
    public class HistorialrolController : Controller
    {
        private readonly IHistorialrolService _histRolService;
        private readonly IHistorialrolMapper _histRolMapper;

        public HistorialrolController(IHistorialrolService histRolService, IHistorialrolMapper histRolMapper)
        {
            _histRolService = histRolService;
            _histRolMapper = histRolMapper;
        }

        [HttpGet]
        [Route("{legajoEmp:int}")]
        public ActionResult GetSectorById([FromRoute] int legajoEmp)
        {
            ResultDTO<List<HistorialrolDTO>> result = new ResultDTO<List<HistorialrolDTO>>();
            List<HistorialrolDTO> histRols = _histRolService.GetManyByLegajo(legajoEmp);
            if (histRols.IsNullOrEmpty())
            {
                result.ErrorsMessages.Add("Legajo no encontrado!");
                result.StatusCode = NotFound().StatusCode;
                return NotFound(result);
            }
            else
            {
                result.Results = histRols;
                result.StatusCode = Ok().StatusCode;
                return Ok(result);
            }
        }

    }
}