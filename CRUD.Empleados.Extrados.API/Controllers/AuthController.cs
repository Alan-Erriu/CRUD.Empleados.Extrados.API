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


        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest credentials)
        {


            return Ok(await _authServices.LoginService(credentials));



        }

    }
}
