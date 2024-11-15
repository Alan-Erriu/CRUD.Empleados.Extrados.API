using CRUD.Empleados.Extrados.Entities.Models;

namespace CRUD.Empleados.Extrados.Services.Implementations
{
    public interface IPositionServices
    {
        Task<List<Position>> GetAllPostionService();
    }
}