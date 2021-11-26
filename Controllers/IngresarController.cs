using Microsoft.AspNetCore.Mvc;
using Taqueria.Context;
using Taqueria.Models;
using Taqueria.Services;

namespace Taqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresarController : ControllerBase
    {
        private readonly Data context;
        private readonly IJsonWebToken jsonWebToken;

        public IngresarController(Data context, IJsonWebToken jsonWebToken)
        {
            this.context = context;
            this.jsonWebToken = jsonWebToken;
        }

        // POST api/<UsuarioController>/ingresar
        [HttpPost]
        public IActionResult Ingresar([FromBody] Credencial credencial)
        {
            var usuario = context.Usuario.FirstOrDefault(u => u.Correo == credencial.Correo);
            if (usuario != null)
            {
                if (Encriptacion.EncriptarSHA256(credencial.Contrasena) == usuario.Contrasena)
                {
                    return Ok(jsonWebToken.GenerarToken(usuario));
                }
                else
                {
                    return BadRequest("Correo o contraseña incorrectos.");
                }
            }
            else
            {
                return BadRequest("Correo o contraseña incorrectos.");
            }
        }
    }
}
