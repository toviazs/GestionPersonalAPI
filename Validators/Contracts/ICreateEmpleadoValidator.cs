using APIv2.Models.DTO;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Contracts
{
    public interface ICreateEmpleadoValidator
    {
        public bool IsValid(CreateEmpleadoDTO empleado);
        public List<string> GetErrors(CreateEmpleadoDTO empleado);
    }
}
