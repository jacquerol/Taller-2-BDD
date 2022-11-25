using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taller2base
{
    public partial class ModificarDatos : Form
    {
        public ModificarDatos()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        private void addClienteButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("AddCliente");
            password.Show();
        }
        private void addCategoriaButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("AddCategoria");
            password.Show();
        }
        private void addEmpleadoButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("AddEmpleado");
            password.Show();
        }
        private void addLibroButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("AddLibro");
            password.Show();
        }
        private void addVentaButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("AddVenta");
            password.Show();
        }
        private void agregarDineroButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("AgregarDinero");
            password.Show();
        }
        private void cambiarSalarioButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("CambiarSalario");
            password.Show();
        }
        private void eliminarClienteButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("EliminarCliente");
            password.Show();
        }
        private void modificarDescuentoButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("ModificarDescuentoLibro");
            password.Show();
        }
        private void aumentarStockLibroButton_Click(object sender, EventArgs e)
        {
            Password password = new Password("IncStockLibro");
            password.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModificarDatos_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
