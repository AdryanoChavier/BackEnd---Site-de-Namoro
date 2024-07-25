using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace BackEnd.Controllers
{
    public class ContaController : BaseController
    {
        private readonly DataContext _context;

        public ContaController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUsuario>> Registrar(string usuario_nome,string senha)
        {
            using var hmac = new HMACSHA512();

            var usuario = new AppUsuario
            {
                usuario_nome = usuario_nome,
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha)),
                passwordSalt = hmac.Key
            };
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }
        
    }
}
