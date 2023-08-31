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

        public string Listar()
        {
            string respuesta = "";

            foreach(Producto item in Lista)
            {
                if (item == null)
                {
                    break;
                }
                respuesta = respuesta + item.Listar() + "\r\n";
            }

            return respuesta;
        }

        public Producto BuscarProducto(string codigo)
        {
            Producto Prod = new Producto();

            foreach(Producto item in Lista)
            {
                if (item == null) 
                { 
                    break; 
                }
                if (item.Codigo == codigo)
                {
                    Prod = item;
                    break;
                }
            }
            return Prod;
        }

        public int BuscarRenglonProducto(string codigo)
        {
            int fila = -1;
            for (int i = 0; i <= Lista.Length; i++)
            {
                if (Lista[i]==null)
                {
                    break;
                }

                if (Lista[i].Codigo == codigo)
                { 
                    fila = i; 
                    break;
                }
            }
            return fila;
        }

        public bool ModificarProducto(string codigo, string nombre, decimal precio)
        {
            bool resp = false;
            int filaAModificar = BuscarRenglonProducto(codigo);

            if (filaAModificar != -1)
            {
                Lista[filaAModificar].Modificar(codigo, nombre, precio);
                resp = true;    
            }

            return resp;
        }

        //public void ModificarProducto(string codigo, string nombre, decimal precio)
        //{
        //    Producto prodAModificar = BuscarProducto(codigo);

        //    if (prodAModificar.Codigo != null)
        //    {
        //        prodAModificar.Modificar(codigo, nombre, precio);

        //        int filaAModificar = BuscarRenglonProducto(codigo);

        //        Lista[filaAModificar] = prodAModificar;
        //    }
        //}

        public bool BorrarProducto(string codigo)
        {
            bool pudeborrar = false;

            int filaaBorra = BuscarRenglonProducto(codigo);
            if (filaaBorra != -1)
            {
                Lista[filaaBorra] = Lista[fila - 1]; //copio elúltimo en la fila a borrar
                
                Lista[fila - 1] = null; //el ultimo convierto a null

                fila = fila - 1; // acomodo el renglon del nuevo producto a crear
                pudeborrar = true;
            }
            return pudeborrar;
        }
    }
}
