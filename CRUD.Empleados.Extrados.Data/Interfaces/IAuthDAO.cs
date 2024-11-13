using CRUD.Empleados.Extrados.Entities;

namespace CRUD.Empleados.Extrados.Data.Interfaces
{
    public interface IAuthDAO
    {
        Task<Client?> Login(string email);
    }
}