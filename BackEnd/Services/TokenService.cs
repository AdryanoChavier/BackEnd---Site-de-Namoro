using BackEnd.Data;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BackEnd.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(AppUsuario usuario)
        {
            var tokenKey = _config["TokenKey "] ?? throw new Exception("Erro em acessar o tokenKey");
            if (tokenKey.Length < 64) throw new Exception("Seu TokeKey precisa ser mais longo");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            
        }
    }
}
