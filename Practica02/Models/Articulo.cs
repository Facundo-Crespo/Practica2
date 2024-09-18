using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Articulo
{
    public int Id_Articulo { get; set; }
    public string Nombre { get; set; }
    public double PrecioUnitario { get; set; }

    public Articulo(int id, double precioUnitario, string nombre)
    {
        this.Id_Articulo = id;
        this.PrecioUnitario = precioUnitario;
        this.Nombre = nombre;
    }
}
