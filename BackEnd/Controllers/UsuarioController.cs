
using AutoMapper;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BackEnd.Controllers
{
    [Authorize]
    public class UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper) : BaseController
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

        [HttpPut]
        public async Task<ActionResult> UpdateUsuario(MembroUpdateDTO membroUpdateDTO)
        {
            var usuarioname = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (usuarioname == null) return BadRequest("Nenhum nome de usuário encontrado no token");

            var usuario = await usuarioRepository.GetUsuarioByNomeAsync(usuarioname);

            if(usuario  == null) return BadRequest("Não foi possível encontrar o usuário");

            mapper.Map(membroUpdateDTO, usuario);

            if (await usuarioRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Aconteceu alguma falha na atualização do usuário");


        }   
    }
}
