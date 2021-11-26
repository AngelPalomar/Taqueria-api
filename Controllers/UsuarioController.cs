using Microsoft.AspNetCore.Mvc;
using Taqueria.Models;
using Taqueria.Context;
using Taqueria.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Data context;
        public UsuarioController(Data context)
        {
            this.context = context;
        }

        // GET: api/<UsuarioController>
        [Authorize]
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return context.Usuario.ToList();
        }

        // GET api/<UsuarioController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var registro = context.Usuario.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                return Ok(registro);
            }
            else
            {
                return NotFound("Registro no encontrado.");
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                //Encripta la contraseña 
                usuario.Contrasena = Encriptacion.EncriptarSHA256(usuario.Contrasena);

                context.Usuario.Add(usuario);
                context.SaveChanges();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // PUT api/<UsuarioController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            var registro = context.Usuario.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    registro.Apellidos = usuario.Apellidos;
                    registro.Correo = usuario.Correo;
                    registro.Direccion = usuario.Direccion;
                    registro.Edad = usuario.Edad;

                    //Encripta la contraseña si se mandó una nueva
                    if (usuario.Contrasena == string.Empty)
                    {
                        registro.Contrasena = Encriptacion.EncriptarSHA256(usuario.Contrasena);
                    }

                    context.SaveChanges();

                    return Ok(registro);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                    throw;
                }
            }
            else
            {
                return NotFound("Registro no encontrado.");
            }
        }

        // DELETE api/<UsuarioController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registro = context.Usuario.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    context.Usuario.Remove(registro);
                    context.SaveChanges();

                    return Ok($"Registro eliminado. ID: {id}");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                    throw;
                }
            }
            else
            {
                return NotFound("Registro no encontrado.");
            }
        }
    }
}
