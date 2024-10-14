using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCorporativo.Data;
using ProjetoCorporativo.Models;

namespace ProjetoCorporativo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DemandaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Demanda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demanda>>> GetDemandas()
        {
            return await _context.Demandas.ToListAsync();
        }

        // GET: api/Demanda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Demanda>> GetDemanda(int id)
        {
            var demanda = await _context.Demandas.FindAsync(id);

            if (demanda == null)
            {
                return NotFound();
            }

            return demanda;
        }

        // POST: api/Demanda
        [HttpPost]
        public async Task<ActionResult<Demanda>> PostDemanda(Demanda demanda)
        {
            _context.Demandas.Add(demanda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDemanda), new { id = demanda.Id }, demanda);
        }

        // PUT: api/Demanda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemanda(int id, Demanda demanda)
        {
            if (id != demanda.Id)
            {
                return BadRequest();
            }

            _context.Entry(demanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Demanda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemanda(int id)
        {
            var demanda = await _context.Demandas.FindAsync(id);
            if (demanda == null)
            {
                return NotFound();
            }

            _context.Demandas.Remove(demanda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DemandaExists(int id)
        {
            return _context.Demandas.Any(e => e.Id == id);
        }
    }
}
