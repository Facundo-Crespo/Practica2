using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FormaPago
{
    public int Id_FormaPago { get; set; }
    public string Nombre { get; set; }
    public FormaPago(int id , string nombre)
    {
        this.Id_FormaPago = id;
        this.Nombre = nombre;
    }
}
