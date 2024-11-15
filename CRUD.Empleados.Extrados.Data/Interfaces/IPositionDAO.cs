using CRUD.Empleados.Extrados.Entities.Models;

namespace CRUD.Empleados.Extrados.Data.Interfaces
{
    public interface IPositionDAO
    {
        Task<List<Position>> GetAllPosition();
    }
}