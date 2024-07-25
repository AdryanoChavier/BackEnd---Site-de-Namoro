using BackEnd.Models;

namespace BackEnd.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUsuario usuario);
    }
}
