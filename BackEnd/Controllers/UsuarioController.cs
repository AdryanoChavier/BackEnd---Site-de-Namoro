
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
    public class UsuarioController(IUsuarioRepository usuarioRepository,IMapper mapper) : BaseController
    {


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembroDTO>>> ObterUsuarios()
        {
            var usuarios = await usuarioRepository.GetUsuarioAsync();
            var usuariosReturn = mapper.Map<IEnumerable<MembroDTO>>(usuarios);
            return Ok(usuariosReturn);
        }

        [HttpGet("{usuario_nome}")]
        public async Task<ActionResult<MembroDTO>> ObterUsuario(string usuario_nome)
        {
            var usuario = await usuarioRepository.GetUsuarioByNomeAsync(usuario_nome);
            if (usuario == null) return NotFound();
            return mapper.Map<MembroDTO>(usuario);
        }
    }
}
