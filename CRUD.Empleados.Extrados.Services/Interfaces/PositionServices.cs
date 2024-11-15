using CRUD.Empleados.Extrados.Data.Interfaces;
using CRUD.Empleados.Extrados.Entities.Models;
using CRUD.Empleados.Extrados.Services.Implementations;

namespace CRUD.Empleados.Extrados.Services.Interfaces
{
    public class PositionServices : IPositionServices
    {
        private readonly IPositionDAO _positionDAO;
        public PositionServices(IPositionDAO positionDAO)
        {
            _positionDAO = positionDAO;
        }

        public async Task<List<Position>> GetAllPostionService()
        {
            return await _positionDAO.GetAllPosition();
        }
    }
}
