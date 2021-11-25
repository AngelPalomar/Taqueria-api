using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taqueria.Models;

namespace Taqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresarController : ControllerBase
    {
        // POST api/<UsuarioController>/ingresar
        [HttpPost("ingresar")]
        public IActionResult Ingresar([FromBody] Credencial credencial)
        {

        }
    }
}
