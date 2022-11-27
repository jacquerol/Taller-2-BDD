
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static DatabaseUtil.Util;

namespace taller2base
{
    public partial class ConsultaDatos : Form
    {
        
        public string receivedData;
        public string[] entidades;
        public ConsultaDatos()
        {
            InitializeComponent();
            entidades = new string[] { "Cliente", "Categoria", "Vendedor", "Orden", "Proveedor", "Producto" };
        }
        public void DatosPorRut(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox)sender; if (!ComponenteLleno(box) || e.KeyChar != ((char)Keys.Enter)) return;
            DataTableDisplay display = new DataTableDisplay(GetTabla("SELECT * FROM CLIENTE WHERE RUT = '" + box.Text + "'"), "Datos del vendedor " + box.Text);
            display.Show();
        }
        
        public void DatosCompra(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(GetTabla("SELECT * FROM ORDEN WHERE IDORDEN = '" + box.SelectedItem.ToString() + "'"), "Datos de la compra "+box.SelectedItem.ToString());
            display.Show();
        } 
        public void ProductosCompradosAnual(object sender, EventArgs e)
        {

        }
        public void CantProductosProveedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            MessageBox.Show(GetDato("select DISTINCT count(suministra.idProducto) " +
                "from((suministra inner join producto on suministra.idProducto = producto.id) " +
                "inner join proveedor on suministra.rutProveedor = proveedor.rut and " +
                "proveedor.rut = '" + box.SelectedItem.ToString() + "')"), "Cantidad de productos de "+box.SelectedItem.ToString()); 
        }
        public void DatosVendedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(GetTabla("SELECT * FROM VENDEDOR WHERE NUMEMPLEADO = '" + box.SelectedItem.ToString() + "'"), "Datos del vendedor " + box.SelectedItem.ToString());
            display.Show();
        }
        public void ProductosDeProveedor(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(GetTabla(
                "select producto.precioVenta, count(*) " +
                "from((proveedor inner join suministra on proveedor.rut = suministra.rutProveedor and proveedor.rut = " +
                box.SelectedItem.ToString() +
                ") " +
                "inner join producto on suministra.idProducto = producto.id)"),
                "Productos del proveedor " + box.SelectedItem.ToString());
            display.Show();
        }
        public void ProveedoresDeProducto(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DataTableDisplay display = new DataTableDisplay(
                GetTabla("select distinct p.nombre, p.rut from producto inner join suministra on suministra.idproducto = producto.id and producto.id = '" + box.SelectedItem.ToString() +
                "' inner join proveedor p on p.rut = suministra.rutproveedor"), 
                "Proveedores del producto " + box.SelectedItem.ToString());
            display.Show();
        }
        public void ProductosCompradosPorCategoria(object sender, EventArgs e)
        {

        }
        public void ProductosCompradosPorDia(object sender, EventArgs e)
        {

        }
        public void ProductosCategoria(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            MessageBox.Show(GetDato("select distinct count(p.nombre) from categoria c inner join producto p where p.idcategoria = c.id and c.id = '" + box.SelectedItem.ToString() + "'"), "Cantidad");
        }
        public void CategoriaProducto(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; if (!ComponenteLleno(box)) return;
            DesplegarDatos(GetTabla("select c.nombre from categoria c inner join producto p where p.idcategoria = c.id and p.id = '" + box.SelectedItem.ToString() +  "'"));
        }
        public void VendedoresAntiguedad(object sender, EventArgs e)
        {

        }
        public void Top5Semana(object sender, EventArgs e)
        {

        }
        public void ProductosSinDemanda(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// cringe
        /// función que trabaja con los datos del cliente para poder consultar los datos correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clientData(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter) return;
            string rut = ""; string nombre; string email; string saldo; string precioNeto;
            using (var form = new ModularForm("cliente", "Datos de un cliente", "Ingrese el rut del cliente"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    rut = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT nombre, email, saldo FROM CLIENTE c INNER JOIN VENTA v on c.rut = v.rutCliente WHERE v.fecha > CURDATE()-90 and c.rut = '" + rut + "'";
                DataTable data = conex.selectQuery(query);
                nombre = data.Rows[0]["nombre"].ToString();
                email = data.Rows[0]["email"].ToString();
                saldo = data.Rows[0]["saldo"].ToString();
                MessageBox.Show("Nombre: " + nombre + "\nCorreo: " + email + "\nSaldo: " + saldo, "Estadísticas del cliente");
                conex.close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message, "Error");
            }
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void DesplegarListadoUniversal(object sender, EventArgs e) {
            object input = ListadoUniversalComboBox.SelectedItem;
            if (input== null) return;
            string text = input.ToString();
            for(int i = 0; i < this.entidades.Length; i++)
            {
                if(text == this.entidades[i]) DesplegarListado((ComboBox)sender, this.entidades[i]);
            }
        }
        public void RellenarCliente(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "cliente"); }
        public void RellenarCategoria(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "categoria"); }
        public void RellenarVendedor(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "vendedor"); }
        public void RellenarCompra(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "orden"); }
        public void RellenarProveedor(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "proveedor"); }
        public void RellenarProducto(object sender, EventArgs e) { RellenarConRegistros((ComboBox)sender, "producto"); }
        public void RellenarListadoUniversal(object sender, EventArgs e) { RellenarComboBox(ListadoUniversalComboBox, this.entidades); }

    }
}
