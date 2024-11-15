using CRUD.Empleados.Extrados.Common.CustomRequest.EmployeeRequest;
using CRUD.Empleados.Extrados.Entities.DTOs;
using CRUD.Empleados.Extrados.Entities.Models;

namespace CRUD.Empleados.Extrados.Data.Interfaces
{
    public interface IEmployeeDAO
    {
        Task<int> CreateEmployee(CreateEmployeeRequest request);

        Task<int> UpdateStatusEmployee(int userId, int statusEmployee);

        Task<int> UpdateEmployee(User employee);

        Task<List<EmployeeDTO>> GetAllEmployees(int pageNumber, int pageSize);
    }
}