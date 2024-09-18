

using ProduccionBack.Entities;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProduccionBack.Data
{
    public class FacturaRepository : IFacturaRepository
    {

        public bool InsertarFactura(Factura factura, int idArticulo, int cantidad)
        {
            bool aux = true;
            SqlConnection conexion = DBHelper.GetInstancia().GetConnection();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();

                SqlCommand cmd = new SqlCommand("InsertarFacturaMaster", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@idFactura", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p);

                cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@nro_factura", factura.Nro);
                cmd.Parameters.AddWithValue("@formaPago", factura.FormaPago);
                cmd.Parameters.AddWithValue("@cliente", factura.Cliente);

                cmd.ExecuteNonQuery();

                int idFactura = (int)p.Value;
                var detalle = new DetalleFactura(idFactura, idArticulo, cantidad);



                factura.AgregarDetalle(detalle);

                foreach (DetalleFactura det in factura.ListaDetalles)
                {
                    SqlCommand cmd2 = new SqlCommand("InsertarDetalleFactura", conexion, t);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@nro_orden", idFactura);
                    cmd2.Parameters.AddWithValue("@idArticulo", det.IdArticulo);
                    cmd2.Parameters.AddWithValue("@cantidad", det.Cantidad);
                    cmd2.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch (Exception)
            {
                if (t != null)
                {
                    aux = false;
                    t.Rollback();
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return aux;
        }





        public List<Articulo> ObtenerArticulos()
        {
            DataTable tabla = DBHelper.GetInstancia().Consultar("ConsultarArticulos");
            List<Articulo> lista = new List<Articulo>();

            foreach (DataRow row in tabla.Rows)
            {
                int id = Convert.ToInt32(row["Id_Articulo"]);
                double precioUnitario = double.Parse(row["PrecioUnitario"].ToString());  
                string nombre = row["Nombre"].ToString();

                Articulo art = new Articulo(id, precioUnitario, nombre);  
                lista.Add(art);
            }

            return lista;
        }

        public List<Factura> ObtenerFacturas()
        {
            DataTable tabla = DBHelper.GetInstancia().Consultar("ConsultarFacturas");
            List<Factura> lista = new List<Factura>();

            foreach (DataRow row in tabla.Rows)
            {
                int id = Convert.ToInt32(row["Id_Factura"]);
                int numeroFactura = int.Parse(row["NumeroFactura"].ToString());
                DateTime fecha = Convert.ToDateTime(row["Fecha"]);
                int formaPagoId = Convert.ToInt32(row["FormaPagoId"]);
                string cliente = row["Cliente"].ToString();
                Factura fac = new Factura(id,formaPagoId,fecha,cliente);

                lista.Add(fac);
            }

            return lista;
        }

        public List<FormaPago> ObtenerFormasPago()
        {
            DataTable tabla = DBHelper.GetInstancia().Consultar("ConsultarFormasPago");
            List<FormaPago> lista = new List<FormaPago>();

            foreach (DataRow row in tabla.Rows)
            {
                int id = Convert.ToInt32(row["Id_FormaPago"]);
                string nombre = row["Nombre"].ToString();

                FormaPago fp = new FormaPago(id , nombre);
                lista.Add(fp);
            }

            return lista;
        }

    }
}
