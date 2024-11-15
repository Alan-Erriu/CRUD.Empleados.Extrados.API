using System.ComponentModel.DataAnnotations;

namespace CRUD.Empleados.Extrados.Common.CustomRequest.EmployeeRequest
{
    public class GetEmployeesRequest
    {
        [Required]
        public int pageNumber { get; set; }
        [Required]
        public int pageSize { get; set; }

    }
}
