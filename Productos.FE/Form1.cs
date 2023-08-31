using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Productos.BE;

namespace Productos.FE
{
    public partial class Form1 : Form
    {
        ListaProductos lista = new ListaProductos();
        public Form1()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Producto producto = new Producto();

                producto.Codigo = txtCodigo.Text;
                producto.Nombre = txtProducto.Text;
                producto.Precio = Convert.ToDecimal(txtPrecio.Text);

                lista.AgregarProducto(producto);

                lblResultado.Text = lista.Listar();

                LimpiarPantalla();
            }
            else
            {
                lblResultado.Text = "Datos Incorrectos";
                txtCodigo.Focus();
                txtCodigo.SelectAll();
            }

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Producto producto = lista.BuscarProducto(txtCodigo.Text);

            if(producto.Codigo==null)
            {
                txtProducto.Text = "";
                txtPrecio.Text = "";
                lblResultado.Text = "No se encontró el código buscado";
            }
            else
            {
                txtProducto.Text = producto.Nombre;
                txtPrecio.Text=producto.Precio.ToString();
                lblResultado.Text = "Producto encontrado";

            }
            txtCodigo.Focus();
            txtCodigo.SelectAll();
        }

        private void btListar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = lista.Listar();

        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            bool resp =  lista.ModificarProducto(txtCodigo.Text, 
                                   txtProducto.Text, 
                                   Convert.ToDecimal( txtPrecio.Text));
            if(!resp)
            {
                lblResultado.Text = "No se pudo modificar el producto de código "
                                     + txtCodigo.Text; ;
            }
            lblResultado.Text = lista.Listar();
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            bool resp = lista.BorrarProducto(txtCodigo.Text);

            if(resp) 
            {
                lblResultado.Text = "El producto de código "
                    + txtCodigo.Text
                    + " a sido borrado.";
            }
            else
            {
                lblResultado.Text = "El producto de código "
                    + txtCodigo.Text
                    + " NO pudo ser borrado.";
            }

            LimpiarPantalla();
        }

        private void LimpiarPantalla()
        {
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "0";

            txtCodigo.Focus();
        }

        private bool ValidarDatos()
        {
            bool res = false;

            if(txtCodigo.Text!="" 
                && txtProducto.Text != ""
               )
            {
                res = true;
            }


            return res;
        }
    }
}
