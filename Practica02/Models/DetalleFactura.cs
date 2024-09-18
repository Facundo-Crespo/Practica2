using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProduccionBack.Entities
{
    public class DetalleFactura
    {

        public int Id_DetalleFactura { get; set; }

        public int IdFactura { get; set; }

        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }


        public DetalleFactura(int idFactura, int idArticulo, int cantidad)
        {
            IdFactura = idFactura;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
        }

    }
}
