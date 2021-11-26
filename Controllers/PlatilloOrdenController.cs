using Microsoft.AspNetCore.Mvc;
using Taqueria.Models;
using Taqueria.Context;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taqueria.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloOrdenController : ControllerBase
    {
        private readonly Data context;
        public PlatilloOrdenController(Data context)
        {
            this.context = context;
        }

        // GET: api/<PlatilloOrdenController>
        [HttpGet]
        public IEnumerable<PlatilloOrden> Get()
        {
            return context.PlatilloOrden.ToList();
        }

        // GET api/<PlatilloOrdenController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var registro = context.PlatilloOrden.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                return Ok(registro);
            }
            else
            {
                return NotFound("Registro no encontrado.");
            }
        }

        // POST api/<PlatilloOrdenController>
        [HttpPost]
        public IActionResult Post([FromBody] PlatilloOrden platilloOrden)
        {
            try
            {
                context.PlatilloOrden.Add(platilloOrden);
                context.SaveChanges();

                return Ok(platilloOrden);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // PUT api/<PlatilloOrdenController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlatilloOrden platilloOrden)
        {
            var registro = context.PlatilloOrden.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    registro.IdOrden = platilloOrden.IdOrden;
                    registro.IdPlatillo = platilloOrden.IdPlatillo;
                    registro.Cantidad = platilloOrden.Cantidad;
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

        // DELETE api/<PlatilloOrdenController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registro = context.PlatilloOrden.FirstOrDefault(d => d.Id == id);
            if (registro != null)
            {
                try
                {
                    context.PlatilloOrden.Remove(registro);
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
