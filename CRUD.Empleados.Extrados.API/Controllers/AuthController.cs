using CRUD.Empleados.Extrados.Common.CustomRequest.AuthRequest;
using CRUD.Empleados.Extrados.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Empleados.Extrados.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        /// <summary>
        ///  ingresar usuario y  contraseña, de ser credenciales validas se retornara un el email
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest credentials)
        {


            return Ok(await _authServices.LoginService(credentials));



        }

    }
}
