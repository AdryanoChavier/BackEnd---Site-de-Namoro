using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<AppUsuario>> Registrar(RegistroDTO registroDTO)
        {
            if (await UsuarioExiste(registroDTO.Usuario_nome)) return BadRequest("Nome do usuário indisponível");

            using var hmac = new HMACSHA512();

            var usuario = new AppUsuario
            {
                usuario_nome = registroDTO.Usuario_nome.ToLower(),
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registroDTO.Senha)),
                passwordSalt = hmac.Key
            };
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }

        public async Task<ActionResult<AppUsuario>> Login(LoginDTO loginDTO)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.usuario_nome == loginDTO.Usuairo_nome.ToLower());

            if (usuario == null) return Unauthorized("Usuário inválido");
            using var hmac = new HMACSHA512(usuario.passwordSalt);
            var computehash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Senha));

            for (int i = 0; i < computehash.Length; i++) 
            {
                if (computehash[i] != usuario.passwordHash[i]) return Unauthorized("Senha inválida");
            }

            return Ok(usuario);
        }


        private async Task<bool> UsuarioExiste(string usuario_nome)
        {
            return await _context.Usuario.AnyAsync(x => x.usuario_nome.ToLower() == usuario_nome.ToLower());
        }



        
    }
}
