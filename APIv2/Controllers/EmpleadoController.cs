using APIv2.Mappers.Contracts;
using APIv2.Models;
using APIv2.Data;
using APIv2.Models.DTO;
using APIv2.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using APIv2.Data.Configurations;
using System.ComponentModel.DataAnnotations;
using Validators.Contracts;
using Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace APIv2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Empleado")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly ICreateEmpleadoValidator _createEmpleadoValidator;
        private readonly IEmpleadoValidator _empleadoValidator;

        public EmpleadoController(IEmpleadoService empleadoService, ICreateEmpleadoValidator createEmpleadoValidator, IEmpleadoValidator empleadoValidator)
        {
            _empleadoService = empleadoService;
            _createEmpleadoValidator = createEmpleadoValidator;
            _empleadoValidator = empleadoValidator;
        }

        [HttpGet]
        public ActionResult GetEmpleados()
        {
            ResultDTO<List<EmpleadoDTO>> result = new ResultDTO<List<EmpleadoDTO>>();
            result.Results = _empleadoService.GetAll();
            result.StatusCode = Ok().StatusCode;
            return Ok(result);
        }

        [HttpGet]
        [Route("Detalle")]
        public ActionResult GetEmpleadosDetalle()
        {
            ResultDTO<List<EmpleadoDetalleDTO>> result = new ResultDTO<List<EmpleadoDetalleDTO>>();
            result.Results = _empleadoService.GetAllEmpleadoDetalle();
            result.StatusCode = Ok().StatusCode;
            return Ok(result);
        }

        [HttpGet]
        [Route("Detalle/{legajoEmp:int}")]
        public ActionResult GetEmpleadoDetalle([FromRoute] int legajoEmp)
        {
            ResultDTO<EmpleadoDetalleDTO> result = new ResultDTO<EmpleadoDetalleDTO>();
            EmpleadoDetalleDTO? emp = _empleadoService.GetEmpleadoDetalleById(legajoEmp);
            if (emp == null)
            {
                result.ErrorsMessages.Add("Empleado no encontrado!");
                result.StatusCode = NotFound().StatusCode;
                return NotFound(result);
            }
            else
            {
                result.Results = emp;
                result.StatusCode = Ok().StatusCode;
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("{legajoEmp:int}")]
        public ActionResult GetEmpleadoByLegajo([FromRoute] int legajoEmp)
        {
            ResultDTO<EmpleadoDTO> result = new ResultDTO<EmpleadoDTO>();
            EmpleadoDTO? emp = _empleadoService.GetById(legajoEmp);
            if (emp == null) {
                result.ErrorsMessages.Add("Empleado no encontrado!");
                result.StatusCode = NotFound().StatusCode;
                return NotFound(result);
            } 
            else {
                result.Results = emp;
                result.StatusCode = Ok().StatusCode;
                return Ok(result);
            }
        }

        [HttpPut]
        [Route("{legajoEmp:int}")]
        public ActionResult EditEmpleado([FromRoute] int legajoEmp, [FromBody] EmpleadoDTO empleado) {

            ResultDTO<EmpleadoDTO> result = new ResultDTO<EmpleadoDTO>();

            // Verificar si empleado es valido
            if(!ModelState.IsValid || legajoEmp != empleado.LegajoEmpleado)
            {
                result.ErrorsMessages.Add("Empleado no valido");
                result.StatusCode = BadRequest().StatusCode;
                return BadRequest(result);
            }

            // Verificar si cumple requisitos de campo
            if(!_empleadoValidator.IsValid(empleado))
            {
                result.ErrorsMessages.AddRange(_empleadoValidator.GetErrors(empleado));
                result.StatusCode = BadRequest().StatusCode;
                return BadRequest(result);
            }

            // Editar empleado
            try
            {
                bool isEdited = _empleadoService.EditEmpleado(legajoEmp, empleado);
                if (!isEdited)
                {
                    result.ErrorsMessages.Add("Empleado no encontrado!");
                    result.StatusCode = NotFound().StatusCode;
                    return NotFound(result);
                }
            }
            catch (Exception ex)
            {
                result.ErrorsMessages.Add(ex.Message);
                result.StatusCode = BadRequest().StatusCode;
                return BadRequest(result);
            }
                
            _empleadoService.SaveChanges();

            result.StatusCode = Ok().StatusCode;
            result.Results = empleado;
            return Ok(result);
        }

        [HttpDelete]
        [Route("{legajoEmp}")]
        public ActionResult DeleteEmpleado([FromRoute] int legajoEmp)
        {
            ResultDTO<EmpleadoDTO> result = new ResultDTO<EmpleadoDTO>();
            bool isDeleted = _empleadoService.DeleteEmpleado(legajoEmp);
            if(!isDeleted)
            {
                result.ErrorsMessages.Add("Empleado no encontrado");
                result.StatusCode = NotFound().StatusCode;
                return NotFound(result);
            }
            _empleadoService.SaveChanges();
            EmpleadoDTO? empleado = _empleadoService.GetById(legajoEmp);
            result.Messages.Add("Empleado borrado correctamente");  
            result.StatusCode = Ok().StatusCode;
            result.Results = empleado;
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CrearEmpleado([FromBody] CreateEmpleadoDTO empleado)
        {
            ResultDTO<EmpleadoDTO> result = new ResultDTO<EmpleadoDTO>();

            // Verificar si empleado es valido
            if (!ModelState.IsValid)
            {
                result.ErrorsMessages.Add("Empleado no valido");
                result.StatusCode = BadRequest().StatusCode;
                return BadRequest(result);
            }

            // Verificar si cumple requisitos de campo
            if (!_createEmpleadoValidator.IsValid(empleado))
            {
                result.Messages.AddRange(_createEmpleadoValidator.GetErrors(empleado));
                result.StatusCode = BadRequest().StatusCode;
                return BadRequest(result);
            }

            try
            {
                EmpleadoDTO empleadoAgregado = _empleadoService.AddEmpleado(empleado);
                _empleadoService.SaveChanges();

                result.Results = empleadoAgregado;
                result.StatusCode = Ok().StatusCode;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.Message);
                result.StatusCode = BadRequest().StatusCode;
                return BadRequest(result);
            }
        }
    }
}
