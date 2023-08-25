using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.BE
{
    public class ListaProductos
    {
        public Producto[] Lista { get; set; } = new Producto[10];

        private int fila = 0;   

        public void AgregarProducto(Producto dato)
        {
            Lista[fila] = dato;
            fila=fila+1;
        }
    }
}
