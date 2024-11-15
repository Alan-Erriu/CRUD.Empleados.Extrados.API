using CRUD.Empleados.Extrados.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Empleados.Extrados.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionServices _positionServices;
        public PositionController(IPositionServices positionServices)
        {
            _positionServices = positionServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostions()
        {
            return Ok(await _positionServices.GetAllPostionService());

        }
    }
}
