using Microsoft.AspNetCore.Mvc;
using Taqueria.Context;
using Taqueria.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloController : ControllerBase
    {
        private readonly Data context;
        public PlatilloController(Data context)
        {
            this.context = context;
        }

        // GET: api/<PlatilloController>
        [HttpGet]
        public IEnumerable<Platillo> Get()
        {
            return context.Platillo.ToList();
        }

        // GET api/<PlatilloController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var registro = context.Platillo.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                return Ok(registro);
            }
            else
            {
                return NotFound("Registro no encontrado.");
            }
        }

        // POST api/<PlatilloController>
        [HttpPost]
        public IActionResult Post([FromBody] Platillo platillo)
        {
            try
            {
                context.Platillo.Add(platillo);
                context.SaveChanges();

                return Ok(platillo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // PUT api/<PlatilloController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Platillo platillo)
        {
            var registro = context.Platillo.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    registro.Nombre = platillo.Nombre;
                    registro.Precio = platillo.Precio;
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

        // DELETE api/<PlatilloController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registro = context.Platillo.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    context.Platillo.Remove(registro);
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
