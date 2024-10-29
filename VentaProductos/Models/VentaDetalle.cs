namespace VentaProducto.Models;

public class VentasDetalle
{
    public int Id { get; set; }

    public float? Producto { get; set; }


    public int ClienteId { get; set; }
    public virtual Cliente? Cliente { get; set; }

    public int VentasId { get; set; }
    public virtual Ventas? Ventas { get; set; }
}