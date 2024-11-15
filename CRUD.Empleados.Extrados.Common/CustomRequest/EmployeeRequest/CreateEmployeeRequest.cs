using System.ComponentModel.DataAnnotations;

namespace CRUD.Empleados.Extrados.Common.CustomRequest.EmployeeRequest
{
    public class CreateEmployeeRequest
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string lastName { get; set; }
        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public DateTime date_of_birth { get; set; }
        [Required]
        public int PositionId { get; set; }
    }
}
