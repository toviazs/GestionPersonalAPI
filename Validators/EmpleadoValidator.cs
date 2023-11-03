using APIv2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Validators.Contracts;

namespace Validators
{
    public class EmpleadoValidator : AbstractValidator<EmpleadoDTO>, IEmpleadoValidator
    {
        public EmpleadoValidator()
        {
            RuleFor(e => e.ApellidoEmpleado).MaximumLength(200);
            RuleFor(e => e.Correo).MaximumLength(200);
            RuleFor(e => e.Cuil.ToString()).Length(11).WithMessage("El CUIL debe contener 11 dígitos.");
            RuleFor(e => e.Direccion).MaximumLength(200);
            RuleFor(e => e.EstadoEmpleado).Length(1).Matches(@"^(A|I)$").WithMessage("El EstadoEmpleado debe ser A(ctivo) o I(nactivo)");
            RuleFor(e => e.FechaContratacion).NotEmpty();
            RuleFor(e => e.FechaNacimiento).NotEmpty();
            RuleFor(e => e.Genero).Length(1).Matches(@"^(F|M)$").WithMessage("El Género debe ser M(asculino) o F(emenino)");
            RuleFor(e => e.NombreEmpleado).MaximumLength(200);
            RuleFor(e => e.Telefono).MaximumLength(20);
        }

        public bool IsValid(EmpleadoDTO empleado)
        {
            return base.Validate(empleado).IsValid;
        }
        public List<string> GetErrors(EmpleadoDTO empleado)
        {
            return base.Validate(empleado).Errors.Select(err => err.ToString()).ToList();
        }
    }
}
