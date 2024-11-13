using CRUD.Empleados.Extrados.Common.CustomRequest.AuthRequest;
using CRUD.Empleados.Extrados.Data.Interfaces;
using CRUD.Empleados.Extrados.Services.Interfaces;
using PlanItUp.Common.CustomExceptions.GenericResponsesExceptions;

namespace CRUD.Empleados.Extrados.Services.Implementations
{
    public class AuthServices : IAuthServices
    {
        private readonly IAuthDAO _authDAO;
        public AuthServices(IAuthDAO authDAO)
        {
            _authDAO = authDAO;
        }


        public async Task<string?> LoginService(LoginRequest crendentials)
        {
            var clientInDB = await _authDAO.Login(crendentials.email);

            if (clientInDB == null) throw new NotFoundException("user not foud");
            if (clientInDB.client_password != crendentials.password) throw new BadRequestException("Email o contraseña incorrecta");


            return clientInDB.client_email;




        }
    }
}
