using APIv2.Models;
using APIv2.Models.DTO;

namespace APIv2.Services.Contracts
{
    public interface IRolService
    {
        public List<RolDTO> GetAll();
        public RolDTO? GetById(int idRol);
    }
}
