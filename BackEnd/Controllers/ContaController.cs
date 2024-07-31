using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Interfaces;
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
        private readonly ITokenService _tokenService;

        public ContaController(DataContext context,ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }


        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDTO>> Registrar(RegistroDTO registroDTO)
        {
            if (await UsuarioExiste(registroDTO.usuario_nome)) return BadRequest("Nome do usuário indisponível");
            return Ok();
            //using var hmac = new HMACSHA512();

            //var usuario = new AppUsuario
            //{
            //    usuario_nome = registroDTO.usuario_nome.ToLower(),
            //    usuario_sobrenome = registroDTO.usuario_sobrenome.ToLower(),
            //    passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registroDTO.senha)),
            //    passwordSalt = hmac.Key
            //};
            //_context.Usuario.Add(usuario);
            //await _context.SaveChangesAsync();

            //return new UsuarioDTO
            //{
            //    usuario_nome = usuario.usuario_nome,
            //    usuario_sobrenome = usuario.usuario_sobrenome,
            //    token = _tokenService.CreateToken(usuario),
            //};
        }





        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login(LoginDTO loginDTO)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.usuario_nome == loginDTO.usuario_nome.ToLower());

            if (usuario == null) return Unauthorized("Usuário inválido");
            using var hmac = new HMACSHA512(usuario.passwordSalt);
            var computehash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.senha));

            for (int i = 0; i < computehash.Length; i++) 
            {
                if (computehash[i] != usuario.passwordHash[i]) return Unauthorized("Senha inválida");
            }

            return new UsuarioDTO
            {
                usuario_nome = usuario.usuario_nome,
                usuario_sobrenome = usuario.usuario_sobrenome,
                token = _tokenService.CreateToken(usuario),
            };
        }


        private async Task<bool> UsuarioExiste(string usuario_nome)
        {
            return await _context.Usuario.AnyAsync(x => x.usuario_nome.ToLower() == usuario_nome.ToLower());
        }



        
    }
}
