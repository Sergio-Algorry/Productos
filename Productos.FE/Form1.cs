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

            //instanciar objeto producto de la clase Producto
            //Producto producto; 
            //inicializar el objeto producto
            //producto = new Producto();

            //Instanciar e inicializar en un solo paso
            Producto producto = new Producto();

            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtProducto.Text;
            producto.Precio = Convert.ToDecimal( txtPrecio.Text);

            lista.AgregarProducto(producto);

            lblResultado.Text = lista.Listar();

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
    }
}
