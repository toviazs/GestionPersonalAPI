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
using Microsoft.AspNetCore.Authorization;

namespace APIv2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Sector")]
    public class SectorController : Controller
    {
        private readonly ISectorService _sectorService;
        private readonly ISectorMapper _sectorMapper;

        public SectorController(ISectorService sectorService, ISectorMapper sectorMapper)
        {
            _sectorService = sectorService;
            _sectorMapper = sectorMapper;
        }

        [HttpGet]
        public ActionResult GetSectores()
        {
            ResultDTO<List<SectorDTO>> result = new ResultDTO<List<SectorDTO>>();
            result.Results = _sectorService.GetAll();
            result.StatusCode = Ok().StatusCode;
            return Ok(result);
        }

        [HttpGet]
        [Route("{idSector:int}")]
        public ActionResult GetSectorById([FromRoute] int idSector)
        {
            ResultDTO<SectorDTO> result = new ResultDTO<SectorDTO>();
            SectorDTO? sector = _sectorService.GetById(idSector);
            if (sector == null)
            {
                result.ErrorsMessages.Add("Sector no encontrado!");
                result.StatusCode = NotFound().StatusCode;
                return NotFound(result);
            }
            else
            {
                result.Results = sector;
                result.StatusCode = Ok().StatusCode;
                return Ok(result);
            }
        }

    }
}
