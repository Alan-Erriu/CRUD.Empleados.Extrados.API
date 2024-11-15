using Configurations;
using CRUD.Empleados.Extrados.Common.CustomRequest.EmployeeRequest;
using CRUD.Empleados.Extrados.Data.Interfaces;
using CRUD.Empleados.Extrados.Entities.DTOs;
using CRUD.Empleados.Extrados.Entities.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace CRUD.Empleados.Extrados.Data.Implementations
{
    public class EmployeeDAO : IEmployeeDAO
    {
        private readonly SQLServerConfig _config;

        private string _insertNewEmployeeQuery = @"INSERT INTO [users] (name, last_name, phone_number, date_of_birth,position_id) values(@Name,@LastName, @PhoneNumber,@DateOfBrith,@PositionId)";
        private string _selectEmployees = @"SELECT 
        u.user_id, u.name, u.last_name, u.phone_number, u.date_of_birth, p.description 
    FROM 
        [users] u
    JOIN 
        [position] p ON p.position_id = u.position_id
    WHERE 
        u.status = 1
    ORDER BY 
        u.user_id
    OFFSET 
        (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT 
        @PageSize ROWS ONLY;";

        private string _updateStatusEmployee = @"UPDATE [users] SET status = @StatusEmployee WHERE user_id = @EmployeeId";

        private string _updateEmployee = "UPDATE [users] SET name = @Name, last_name = @LastName, phone_number = @PhoneNumber, date_of_birth = @Date, position_id = @PositionId WHERE user_id = @UserId";

        public EmployeeDAO(IOptions<SQLServerConfig> config)
        {
            _config = config.Value;
        }


        public async Task<int> CreateEmployee(CreateEmployeeRequest request)
        {
            using (var connect = new SqlConnection(_config.ConnectionString))
            {
                var parameters = new
                {
                    Name = request.name,
                    LastName = request.lastName,
                    PhoneNumber = request.phoneNumber,
                    DateOfBrith = request.date_of_birth,
                    PositionId = request.PositionId,
                };

                var rowsAffected = await connect.ExecuteAsync(_insertNewEmployeeQuery, parameters);
                return rowsAffected;
            }
        }
        //status( 0)  para dar de baja
        //status (1) para dar de alta
        public async Task<int> UpdateStatusEmployee(int employeeId, int statusEmployee)
        {


            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var parameters = new { EmployeeId = employeeId, StatusEmployee = statusEmployee };
                var rowsAffected = await connection.ExecuteAsync(_updateStatusEmployee, parameters);
                return rowsAffected;
            }


        }

        public async Task<int> UpdateEmployee(User employee)
        {

            var parameters = new
            {
                UserId = employee.user_id,
                Name = employee.name,
                LastName = employee.last_name,
                PhoneNumber = employee.phone_number,
                Date = employee.date_of_birth,
                PositionId = employee.position_id,
            };
            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var rowsAffected = await connection.ExecuteAsync(_updateEmployee, parameters);
                return rowsAffected;
            }
        }


        public async Task<List<EmployeeDTO>> GetAllEmployees(int pageNumber, int pageSize)
        {
            var listEmployees = new List<EmployeeDTO>();


            using (var connect = new SqlConnection(_config.ConnectionString))
            {
                connect.Open();
                using (var command = new SqlCommand(_selectEmployees, connect))
                {
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    using (var dr = await command.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            var employeed = new EmployeeDTO();
                            employeed.user_id = int.Parse((dr["user_id"].ToString()));
                            employeed.name = dr["name"].ToString();
                            employeed.last_name = dr["last_name"].ToString();
                            employeed.phone_number = dr["phone_number"].ToString();
                            employeed.date_of_birth = dr["date_of_birth"] != DBNull.Value
                            ? Convert.ToDateTime(dr["date_of_birth"])
                            : DateTime.MinValue;
                            employeed.description = (dr["description"].ToString());
                            listEmployees.Add(employeed);
                        }

                        return listEmployees;
                    }
                }




            }
        }
    }
}