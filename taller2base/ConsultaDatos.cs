
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
        public ConsultaDatos()
        {
            InitializeComponent();
        }
        public void RellenarCliente(object sender, EventArgs e)
        {
            RellenarComboBox((ComboBox)sender,
                FilaALista(GetTabla("SELECT DISTINCT RUT FROM CLIENTE ORDER BY RUT"), 0));
        }
        public void RellenarVendedor(object sender, EventArgs e)
        {
            RellenarComboBox((ComboBox)sender,
                FilaALista(GetTabla("SELECT DISTINCT NUMEMPLEADO FROM VENDEDOR ORDER BY NUMEMPLEADO"), 0));
        }
        public void RellenarCompra(object sender, EventArgs e)
        {
            RellenarComboBox((ComboBox)sender,
                FilaALista(GetTabla("SELECT DISTINCT IDORDEN FROM ORDEN ORDER BY IDORDEN"), 0));
        }
        public void RellenarProveedor(object sender, EventArgs e)
        {
            RellenarComboBox((ComboBox)sender,
                FilaALista(GetTabla("SELECT DISTINCT RUT FROM PROVEEDOR ORDER BY RUT"), 0));
        }
        public void DatosPorRut(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)Keys.Enter)) return;
            DesplegarDatos(GetTabla("SELECT * FROM CLIENTE c WHERE c.rut = '" + rutTextBox.Text + "'"));
        }
        public void RellenarListadoUniversal(object sender, EventArgs e)
        {
            RellenarComboBox(ListadoUniversalComboBox, "Proveedor, Cliente, Producto, Categoria, Vendedor".Split(", "));
        }
        
        public void DatosCompra(object sender, EventArgs e)
        {

        } 
        public void ProductosCompradosAnual(object sender, EventArgs e)
        {

        }
        public void CantProductosProveedor(object sender, EventArgs e)
        {

        }
        
        public void ProductosDeProveedor(object sender, EventArgs e)
        {

        }
        public void ProveedoresDeProducto(object sender, EventArgs e)
        {

        }
        public void ProductosCompradosPorCategoria(object sender, EventArgs e)
        {

        }
        public void ProductosCompradosPorDia(object sender, EventArgs e)
        {

        }
        public void ProductosCategoria(object sender, EventArgs e)
        {

        }
        public void CategoriaProducto(object sender, EventArgs e)
        {

        }
        public void ProveedoresProducto(object sender, EventArgs e)
        {

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

        private void clientData(object sender, KeyPressEventArgs e)
        {

        }
    }
}
