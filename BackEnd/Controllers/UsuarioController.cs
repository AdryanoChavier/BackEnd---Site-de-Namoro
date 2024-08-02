
using BackEnd.Data;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Authorize]
    public class UsuarioController(IUsuarioRepository usuarioRepository) : BaseController
    {


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUsuario>>> ObterUsuarios()
        {
            var usuarios = await usuarioRepository.GetUsuarioAsync();
            return Ok(usuarios);
        }

        [HttpGet("{usuario_nome}")]
        public async Task<ActionResult<AppUsuario>> ObterUsuario(string usuario_nome)
        {
            var usuario = await usuarioRepository.GetUsuarioByNomeAsync(usuario_nome);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }
    }
}
