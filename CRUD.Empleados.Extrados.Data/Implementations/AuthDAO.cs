using Configurations;
using CRUD.Empleados.Extrados.Data.Interfaces;
using CRUD.Empleados.Extrados.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;


namespace CRUD.Empleados.Extrados.Data.Implementations
{
    public class AuthDAO : IAuthDAO
    {
        private readonly SQLServerConfig _config;

        private readonly string _selectClientByEmail = @"SELECT * FROM [client] WHERE client_email = @Email";

        public AuthDAO(IOptions<SQLServerConfig> sqlConfig)
        {
            _config = sqlConfig.Value;
        }


        public async Task<Client?> Login(string email)
        {
            using (var connect = new SqlConnection(_config.ConnectionString))
            {
                var parameters = new
                {
                    Email = email
                };
                var client = await connect.QueryFirstOrDefaultAsync<Client>(_selectClientByEmail, parameters);
                return client;
            }
        }
    }
}
