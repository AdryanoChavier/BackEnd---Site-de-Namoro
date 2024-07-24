
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUsuario>> ObterUsuarios()
        {
            var usuarios = _context.Usuario.ToList();
            return Ok(usuarios);
        }
        [HttpGet("{usuario_id:int}")]
        public ActionResult<AppUsuario> ObterUsuario(int usuario_id)
        {
            var usuario = _context.Usuario.Find(usuario_id);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }
    }
}
