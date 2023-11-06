using APIv2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Validators.Contracts;
using Models.DTO;

namespace Validators
{
    public class CreateEmpleadoValidator : AbstractValidator<CreateEmpleadoDTO>, ICreateEmpleadoValidator
    {
        public CreateEmpleadoValidator()
        {
            RuleFor(e => e.ApellidoEmpleado).MaximumLength(200);
            RuleFor(e => e.Correo).MaximumLength(200);
            RuleFor(e => e.Cuil.ToString()).Length(11).WithMessage("El CUIL debe contener 11 dígitos.");
            RuleFor(e => e.Direccion).MaximumLength(200);
            RuleFor(e => e.FechaContratacion).NotEmpty().WithMessage("FechaContratacion no puede ser nula");
            RuleFor(e => e.FechaNacimiento).NotEmpty().WithMessage("FechaNacimiento no puede ser nula");
            RuleFor(e => e.Genero).Length(1).Matches(@"^(F|M)$").WithMessage("El Género debe ser M(asculino) o F(emenino)");
            RuleFor(e => e.NombreEmpleado).MaximumLength(200);
            RuleFor(e => e.Telefono).MaximumLength(20);
        }

        public bool IsValid(CreateEmpleadoDTO empleado)
        {
            return base.Validate(empleado).IsValid;
        }
        public List<string> GetErrors(CreateEmpleadoDTO empleado)
        {
            return base.Validate(empleado).Errors.Select(err => err.ToString()).ToList();
        }
    }
}
