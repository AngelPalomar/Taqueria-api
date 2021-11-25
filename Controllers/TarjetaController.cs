using Microsoft.AspNetCore.Mvc;
using Taqueria.Models;
using Taqueria.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly Data context;
        public TarjetaController(Data context)
        {
            this.context = context;
        }

        // GET: api/<TarjetaController>
        [HttpGet]
        public IEnumerable<Tarjeta> Get()
        {
            return context.Tarjeta.ToList();
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var registro = context.Tarjeta.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                return Ok(registro);
            }
            else
            {
                return NotFound("Registro no encontrado.");
            }
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public IActionResult Post([FromBody] Tarjeta tarjeta)
        {
            try
            {
                context.Tarjeta.Add(tarjeta);
                context.SaveChanges();

                return Ok(tarjeta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tarjeta tarjeta)
        {
            var registro = context.Tarjeta.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    registro.IdUsuario = tarjeta.IdUsuario;
                    registro.Numero = tarjeta.Numero;
                    registro.FechaExpiracion = tarjeta.FechaExpiracion;
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

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registro = context.Tarjeta.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    context.Tarjeta.Remove(registro);
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
