using CRUD.Empleados.Extrados.Common.CustomRequest.AuthRequest;

namespace CRUD.Empleados.Extrados.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<string?> LoginService(LoginRequest crendentials);
    }
}