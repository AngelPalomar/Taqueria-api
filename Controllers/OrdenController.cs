using Microsoft.AspNetCore.Mvc;
using Taqueria.Models;
using Taqueria.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly Data context;
        public OrdenController(Data context)
        {
            this.context = context;
        }

        // GET: api/<OrdenController>
        [HttpGet]
        public IEnumerable<Orden> Get()
        {
            return context.Orden.ToList();
        }

        // GET api/<OrdenController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var registro = context.Orden.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                return Ok(registro);
            }
            else
            {
                return NotFound("Registro no encontrado.");
            }
        }

        // POST api/<OrdenController>
        [HttpPost]
        public IActionResult Post([FromBody] Orden orden)
        {
            try
            {
                context.Orden.Add(orden);
                context.SaveChanges();

                return Ok(orden);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // PUT api/<OrdenController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Orden orden)
        {
            var registro = context.Orden.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    registro.IdUsuario = orden.IdUsuario;
                    registro.Total = orden.Total;
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

        // DELETE api/<OrdenController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registro = context.Orden.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    context.Orden.Remove(registro);
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
