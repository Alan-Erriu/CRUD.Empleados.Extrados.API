using CRUD.Empleados.Extrados.Common.CustomRequest.EmployeeRequest;
using CRUD.Empleados.Extrados.Data.Interfaces;
using CRUD.Empleados.Extrados.Entities.DTOs;
using CRUD.Empleados.Extrados.Entities.Models;
using CRUD.Empleados.Extrados.Services.Interfaces;

namespace CRUD.Empleados.Extrados.Services.Implementations
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeDAO _employeeDAO;

        public EmployeeServices(IEmployeeDAO employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }

        public async Task<int> CreateEmployeeService(CreateEmployeeRequest request)
        {


            var rowsAffected = await _employeeDAO.CreateEmployee(request);
            return rowsAffected;


        }

        public async Task<int> UpdateStatusEmployeeService(int employeeId, int statusEmployee)
        {
            return await _employeeDAO.UpdateStatusEmployee(employeeId, statusEmployee);

        }

        public async Task<int> UpdateEmployeeService(User employee)
        {
            return await _employeeDAO.UpdateEmployee(employee);
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeeServices(int pageNumber, int pageSize)
        {
            return await _employeeDAO.GetAllEmployees(pageNumber, pageSize);
        }
    }
}
