using static taller2base.DatabaseUtils;
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

namespace taller2base
{
    public partial class ConsultaDatos : Form
    {

        private DatabaseUtils util;
        public string receivedData;
        public ConsultaDatos()
        {
            InitializeComponent();
            DatabaseUtils util = new DatabaseUtils();
        }

        public void datosPorRut(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)Keys.Enter)) return;
            string mensaje = "";
            MessageBox.Show(util.GetDato("SELECT rut FROM CLIENTE WHERE (cliente.rut = " + rutTextBox.Text + ")"));
            DataTable cliente = this.util.GetTabla("SELECT * FROM CLIENTE WHERE (cliente.rut = " + rutTextBox.Text + ")");
            for (int i = 0; i < cliente.Columns.Count; i++)
            {
                mensaje += cliente.Columns[i].ColumnName + ": " + cliente.Columns[i] + "\n";
            }
            MessageBox.Show(mensaje);
        }

        /// <summary>
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
