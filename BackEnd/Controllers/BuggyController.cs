using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController(DataContext context) : BaseController
    {
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetAuth()
        {
            return "secret Text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUsuario> GetNotFound()
        {
            var thing = context.Usuario.Find(-1);
            if (thing == null) return NotFound();
            return thing;
        }
        [HttpGet("server-error")]
        public ActionResult<AppUsuario> GetServerError()
        {
          var thing = context.Usuario.Find(-1) ?? throw new Exception("Ruim");
          return thing;
        }
        [HttpGet("bad-request")]
        public ActionResult<AppUsuario> GetBadRequest()
        {
            return BadRequest("Não foi uma solicitação boa");
        }



    }
}
