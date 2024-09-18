using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public interface IAplicacionService
    {
        List<Factura> ConsultarFacturas();
        List<Articulo> ConsultarArticulos();
        List<FormaPago> ConsultarFormasPago();
        bool RegistrarFactura(Factura factura, int idArticulo, int cantidad);



    }
}
