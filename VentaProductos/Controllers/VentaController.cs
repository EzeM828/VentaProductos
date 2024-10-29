using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentaProducto.Models;
using VentaProductos.Models;

namespace VentaProductos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly Context _context;

        public VentaController(Context context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetVentas(int id)
        {
            var cliente = await _context.Ventas.FindAsync(id);

            if (Ventas == null)
            {
                return NotFound();
            }

            return Ventas;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentas(int id,Ventas Cliente)
        {
            if (id != Ventas.Id)
            {
                return BadRequest();
            }

            _context.Entry(Ventas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentasExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostVentas(Ventas cliente)
        {
            _context.Ventas.Add(Ventas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentas", new { id = cliente.Id }, Ventas);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentas(int id)
        {
            var Ventas = await _context.Ventas.FindAsync(id);
            if (Ventas == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(Ventas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentasExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}