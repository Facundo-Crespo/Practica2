using ProduccionBack.Entities;

namespace ProduccionBack.Data
{
    public interface IFacturaRepository
    {
        List<Articulo> ObtenerArticulos();
        List<FormaPago> ObtenerFormasPago();
        List<Factura> ObtenerFacturas();
        bool InsertarFactura(Factura factura,int idArticulo, int cantidad);

    
    }
}
