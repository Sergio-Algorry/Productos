using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.BE
{
    public class Producto
    {
        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        //AW548 - BANANA - $ 154,23
        public string Listar()
        {
            //return Codigo
            //       + " - "
            //       + Nombre
            //       + " - "
            //       + Precio.ToString();

            string respuesta = Codigo
                               + " - "
                               + Nombre
                               + " - "
                               + Precio.ToString();

            return respuesta;
        }

        public void Modificar(string codigo, string nombre, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }
    }
}
