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
    [Route("HistorialSector")]
    public class HistorialsectorController : Controller
    {
        private readonly IHistorialsectorService _histSectorService;
        private readonly IHistorialsectorMapper _histSectorMapper;

        public HistorialsectorController(IHistorialsectorService histSectorService, IHistorialsectorMapper histSectorMapper)
        {
            _histSectorService = histSectorService;
            _histSectorMapper = histSectorMapper;
        }

        [HttpGet]
        [Route("{legajoEmp:int}")]
        public ActionResult GetSectorById([FromRoute] int legajoEmp)
        {
            ResultDTO<List<HistorialsectorDTO>> result = new ResultDTO<List<HistorialsectorDTO>>();
            List<HistorialsectorDTO> histSectors = _histSectorService.GetManyByLegajo(legajoEmp);
            if (histSectors.IsNullOrEmpty())
            {
                result.ErrorsMessages.Add("Legajo no encontrado!");
                result.StatusCode = NotFound().StatusCode;
                return NotFound(result);
            }
            else
            {
                result.Results = histSectors;
                result.StatusCode = Ok().StatusCode;
                return Ok(result);
            }
        }

    }
}
