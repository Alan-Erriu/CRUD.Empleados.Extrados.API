using Configurations;
using CRUD.Empleados.Extrados.Data.Interfaces;
using CRUD.Empleados.Extrados.Entities.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace CRUD.Empleados.Extrados.Data.Implementations
{
    public class PositionDAO : IPositionDAO
    {
        private SQLServerConfig _config;

        private string _selectAllPosition = @"select position_id, description from [position]";
        public PositionDAO(IOptions<SQLServerConfig> config)
        {
            _config = config.Value;
        }


        public async Task<List<Position>> GetAllPosition()
        {
            using (var connect = new SqlConnection(_config.ConnectionString))
            {
                var listPosition = (await connect.QueryAsync<Position>(_selectAllPosition)).ToList();
                return listPosition;
            }

        }
    }
}
