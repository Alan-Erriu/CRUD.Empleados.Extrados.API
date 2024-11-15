using CRUD.Empleados.Extrados.Common.CustomRequest.EmployeeRequest;
using CRUD.Empleados.Extrados.Entities.DTOs;
using CRUD.Empleados.Extrados.Entities.Models;

namespace CRUD.Empleados.Extrados.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Task<int> CreateEmployeeService(CreateEmployeeRequest request);

        Task<int> UpdateStatusEmployeeService(int employeeId, int statusEmployee);

        Task<int> UpdateEmployeeService(User employee);

        Task<List<EmployeeDTO>> GetAllEmployeeServices(int pageNumber, int pageSize);
    }
}