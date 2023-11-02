using APIv2.Mappers.Contracts;
using APIv2.Models.DTO;
using APIv2.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace APIv2.Controllers
{
    [ApiController]
    [Route("Empleado")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IEmpleadoMapper _empleadoMapper;

        public EmpleadoController(IEmpleadoService empleadoService, IEmpleadoMapper empleadoMapper)
        {
            _empleadoService = empleadoService;
            _empleadoMapper = empleadoMapper;
        }

        [HttpGet]
        public ActionResult GetEmpleados()
        {
            ResultDTO<List<EmpleadoDTO>> result = new ResultDTO<List<EmpleadoDTO>>();
            result.Results = _empleadoService.GetAll();
            result.StatusCode = Ok().StatusCode;
            return Ok(result);
        }
    }
}
