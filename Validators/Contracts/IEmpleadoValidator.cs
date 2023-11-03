using APIv2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Contracts
{
    public interface IEmpleadoValidator
    {
        public bool IsValid(EmpleadoDTO empleado);
        public List<string> GetErrors(EmpleadoDTO empleado);
    }
}
