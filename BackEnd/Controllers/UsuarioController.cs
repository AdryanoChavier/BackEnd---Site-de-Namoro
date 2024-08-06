
using AutoMapper;
using BackEnd.Data;
using BackEnd.Dtos;
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
        public async Task<ActionResult<IEnumerable<MembroDTO>>> ObterUsuarios()
        {
            var usuarios = await usuarioRepository.GetMembrosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{usuario_nome}")]
        public async Task<ActionResult<MembroDTO>> ObterUsuario(string usuario_nome)
        {
            var usuario = await usuarioRepository.GetMembroAsync(usuario_nome);
            if (usuario == null) return NotFound();
            return usuario;
        }
    }
}
