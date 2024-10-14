using AccesoADatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerRepository repository = new CustomerRepository();

        public void LlenarCampos(Productos producto)
        {
            txtProductoId.Text = producto.idProducto;
            txtNombre.Text = producto.Nombre;
            textDescripcion.Text = producto.Descripcion;
            txtProveedor.Text = producto.Proveedor;
            textMarca.Text = producto.Marca;
            textStock.Text =producto.Stock.ToString();
            textPrecio.Text = producto.Precio.ToString();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            var producto = repository.ObtenerProductos();
            dataGridView1.DataSource = producto;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var producto = repository.ObtenerPorId(txtBuscar.Text);
            if (producto!=null)
            {
                LlenarCampos(producto);
                txtProductoId.Enabled = false;
            }
            else
            {
                MessageBox.Show("Producto no encontrado");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminados = repository.Eliminados(txtProductoId.Text);

            if (eliminados>0)
            {
                MessageBox.Show("Producto ELiminado");
            }
        }
    }
}
