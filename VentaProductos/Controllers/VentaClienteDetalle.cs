using VentaProducto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VentaProducto .Controllers
{
    [Route("VentaProductoDetalles")]
    [ApiController]
    public class VentaProductoDetallesController : ControllerBase
    {
        private readonly Context _context;

        public VentaProductoDetallesController(Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<VentaProductoDetalle>>> GetVentaProductoDetalle(int id)
        {
            var VentaProductoDetalle = await _context.VentaProducto.Include(x => x.Producto).Where(x => x.VentaProductoId == id).ToListAsync();
            if (VentaProductoDetalle == null)
            {
                return NotFound();
            }

            return VentaProductoDetalle;
        }

        [HttpPost]
        public async Task<ActionResult<VentaProductoDetalle>> PostVentaProductoDetalle(VentaProductoDetalle detalleVentaProducto)
        {
            _context.InscripcionDetalle.Add(detalleVentaProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentaProductoDetalle", new { id = detalleVentaProducto.Id }, detalleProducto);
        }
    }
}