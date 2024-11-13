using System.ComponentModel.DataAnnotations;

namespace CRUD.Empleados.Extrados.Common.CustomRequest.AuthRequest
{
    public class LoginRequest
    {

        [Required]
        [EmailAddress(ErrorMessage = "formato de email incorrecto")]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
